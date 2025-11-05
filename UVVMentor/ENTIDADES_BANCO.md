# Entidades do Banco de Dados

Este documento consolida todas as entidades utilizadas pelo backend, com seus campos, tipos, nulabilidade, padrões e relacionamentos. Ele reflete o que o código espera (rotas e queries) e inclui ajustes recomendados quando o schema atual não cobre 100% das necessidades.

Observação importante: onde for indicado “(recomendado)”, a coluna ainda não está sendo criada por `ensureSchema` em `backend/src/bootstrap.ts`, mas é referenciada pelas rotas; vale incluir no banco.

## users

- id: UUID, PK, not null
- email: text, unique, not null
- password: text, not null
- full_name: text, null
- created_at: timestamptz, not null, default now()

Relacionamentos

- 1:N com profiles (via profiles.user_id, único por usuário)
- 1:N com bookings (student_id, mentor_id)
- 1:N com messages (sender_id)
- 1:N com ratings (student_id, mentor_id)
- 1:N com notifications (user_id)

## profiles

- id: UUID, PK, not null
- user_id: UUID, unique, not null, FK → users(id)
- full_name: text, null  (recomendado – usado em diversas rotas)
- email: text, null  (recomendado – sincronizado com users/me)
- phone: text, null
- avatar_url: text, null
- bio: text, null
- location: text, null
- is_mentor: boolean, not null, default false  (recomendado – usado em `estudantes.ts`)
- created_at: timestamptz, not null, default now()
- updated_at: timestamptz, not null, default now()

Relacionamentos

- 1:1 com users (user_id)

Índices sugeridos

- unique(user_id) [já existe]
- index(is_mentor)

## mentor_profiles

- id: UUID, PK, not null
- user_id: UUID, unique, not null, FK → users(id)
- graduation_id: UUID, null, FK → graduations(id)
- experience_years: integer, null
- subjects: text, null (lista/descrição livre; a associação normalizada está em mentor_subjects)
- location: text, null
- availability: text, null  (recomendado – usado em criação/edição de mentor)
- price_per_hour: numeric(10,2), null  (recomendado – usado em criação/edição de mentor)
- avg_rating: decimal(3,2), not null, default 0
- total_ratings: integer, not null, default 0
- created_at: timestamptz, not null, default now()
- updated_at: timestamptz, not null, default now()

Relacionamentos

- N:1 com graduations (graduation_id)
- 1:1 com users (user_id)

## graduations

- id: UUID, PK, not null, default gen_random_uuid()
- name: text, not null
- description: text, null
- created_at: timestamptz, not null, default now()

## subjects

- id: UUID, PK, not null, default gen_random_uuid()
- name: text, not null
- graduation_id: UUID, null, FK → graduations(id)
- created_at: timestamptz, not null, default now()

Relacionamentos

- N:1 com graduations
- N:N com profiles/mentores via mentor_subjects

## mentor_subjects

- id: UUID, PK, not null, default gen_random_uuid()
- mentor_id: UUID, not null, FK → (ver Observação abaixo)
- subject_id: UUID, not null, FK → subjects(id)
- created_at: timestamptz, not null, default now()
- UNIQUE(mentor_id, subject_id)

Índices

- idx_mentor_subjects_mentor_id (mentor_id)
- idx_mentor_subjects_subject_id (subject_id)

Observação sobre FK mentor_id

- As rotas de listagem de disciplinas (`disciplinas.ts`) assumem `mentor_subjects.mentor_id` = `profiles.id` (JOIN em `profiles p ON p.id = ms.mentor_id`).
- Já a criação do schema atual referencia `users(id)`.
- Recomenda-se padronizar para `profiles.id` para aderir à query de disciplinas, ou ajustar a query para usar `p.user_id = ms.mentor_id`. Escolha um padrão e mantenha consistente.

## bookings

- id: UUID, PK, not null, default gen_random_uuid()
- student_id: UUID, not null, FK → users(id)
- mentor_id: UUID, not null, FK → users(id)
- subject_id: UUID, null, FK → subjects(id)
- subject_name: text, null (fallback quando não há subject_id; backend resolve/gera)
- date: date, not null
- time: time, not null
- duration: integer, not null, default 60
- status: text, not null, default 'pending' (valores: 'pending' | 'confirmed' | 'in-progress' | 'completed' | 'cancelled')
- objective: text, null
- student_name: text, null
- student_email: text, null
- student_phone: text, null
- cancel_reason: text, null
- created_at: timestamptz, not null, default now()
- updated_at: timestamptz, not null, default now()

Índices sugeridos

- index(student_id)
- index(mentor_id)
- index(status)

Regras de negócio relevantes

- Só pode ir para `completed` se o status anterior for `confirmed` ou `in-progress`.

## messages

- id: UUID, PK, not null, default gen_random_uuid()
- booking_id: UUID, not null, FK → bookings(id)
- sender_id: UUID, not null, FK → users(id)
- content: text, not null
- created_at: timestamptz, not null, default now()

Índices

- idx_messages_booking_id (booking_id)

## notifications

- id: UUID, PK, not null, default gen_random_uuid()
- user_id: UUID, not null, FK → users(id)
- message: text, not null
- booking_id: UUID, null, FK → bookings(id)
- read: boolean, not null, default false
- created_at: timestamptz, not null, default now()

Índices

- idx_notifications_user_id (user_id)

## ratings

- id: UUID, PK, not null, default gen_random_uuid()
- booking_id: UUID, not null, FK → bookings(id)
- student_id: UUID, not null, FK → users(id)
- mentor_id: UUID, not null, FK → users(id)
- rating: integer, not null, CHECK (1..5)
- comment: text, null
- created_at: timestamptz, not null, default now()

Índices

- idx_ratings_booking_id (booking_id)
- idx_ratings_student_id (student_id)
- idx_ratings_mentor_id (mentor_id)

---

## Checklist de consistência entre código e schema

- [ ] profiles tem `full_name`, `email` e `is_mentor` (rotas `perfis.ts`, `estudantes.ts`, `usuarios.ts` dependem desses campos)
- [ ] mentor_profiles tem `availability` e `price_per_hour` (rotas `mentores.ts` usam esses campos)
- [ ] Padrão de FK de `mentor_subjects.mentor_id` decidido e consistente com as queries (recomendado `profiles.id` OU ajustar queries para `p.user_id = ms.mentor_id`)
- [X] bookings possui `subject_name` e `cancel_reason`
- [X] ratings com `CHECK (rating BETWEEN 1 AND 5)`

Se quiser, posso ajustar `ensureSchema` para criar/adicionar automaticamente as colunas recomendadas e alinhar a FK de `mentor_subjects` ao padrão escolhido.
