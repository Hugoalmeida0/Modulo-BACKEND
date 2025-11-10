# 📘 Projeto: Gerenciador de Estudos

## 🧩 Visão Geral

O **Gerenciador de Estudos** é um sistema full stack desenvolvido para organizar e acompanhar o progresso de estudos de um usuário.
O objetivo é permitir que cada usuário cadastre matérias, tópicos e sessões de estudo, acompanhando o tempo investido e visualizando o progresso em um painel.

---

## 🧱 Arquitetura DDD Utilizada

O projeto segue a arquitetura **DDD (Domain-Driven Design)**, estruturada em módulos independentes para garantir separação de responsabilidades e escalabilidade:

```
src/
├── API
│   └── Controllers/
│   └── Program.cs
│   └── appsettings.json
│
├── Aplicacao
│   └── Services/
│   └── Interfaces/
│
├── DataTransfer
│   └── DTOs/
│
├── Dominio
│   ├── Entidades/
│   ├── Repositorios/
│   ├── Servicos/
│   └── ValueObjects/
│
├── Dominio.Testes
│   └── Unit/
│
├── Infra
│   ├── Mapeamentos/
│   ├── NHibernate/
│   ├── Repositorios/
│   └── Contexto/
│
└── Jobs
    └── Rotinas/
```

---

## 🧠 Entidades Principais

### **Aluno**

Representa o usuário que utiliza o sistema.

| Campo       | Tipo     | Descrição                |
| ----------- | -------- | -------------------------- |
| Id          | Guid     | Identificador único       |
| Nome        | string   | Nome completo do aluno     |
| Email       | string   | E-mail de login            |
| SenhaHash   | string   | Hash da senha              |
| DataCriacao | DateTime | Data de criação da conta |

---

### **Materia**

Representa uma matéria ou disciplina que o aluno deseja estudar.

| Campo     | Tipo    | Descrição                           |
| --------- | ------- | ------------------------------------- |
| Id        | Guid    | Identificador único                  |
| Nome      | string  | Nome da matéria                      |
| Descricao | string? | Descrição opcional                  |
| AlunoId   | Guid    | Referência ao Aluno dono da matéria |

---

### **Topico**

Cada matéria pode ter diversos tópicos.

| Campo     | Tipo   | Descrição                        |
| --------- | ------ | ---------------------------------- |
| Id        | Guid   | Identificador único               |
| Nome      | string | Nome do tópico                    |
| MateriaId | Guid   | Referência à matéria            |
| Concluido | bool   | Indica se o tópico foi concluído |

---

### **SessaoEstudo**

Registra uma sessão de estudo (tempo investido em uma matéria).

| Campo          | Tipo     | Descrição                      |
| -------------- | -------- | -------------------------------- |
| Id             | Guid     | Identificador único             |
| MateriaId      | Guid     | Referência à matéria estudada |
| DuracaoMinutos | int      | Duração em minutos             |
| DataSessao     | DateTime | Data em que ocorreu o estudo     |

---

## ⚙️ Regras de Negócio

1. Um **Aluno** pode ter várias **Matérias**.
2. Cada **Matéria** possui múltiplos **Tópicos**.
3. Cada **Sessão de Estudo** pertence a uma única **Matéria**.
4. O progresso de uma matéria pode ser calculado pela proporção de tópicos concluídos.
5. O total de horas estudadas é somado a partir das sessões de estudo.

---

## 🔗 Endpoints Principais (API)

### **/api/alunos**

- `POST /api/alunos` → Criar novo aluno
- `GET /api/alunos/{id}` → Obter aluno por ID

### **/api/materias**

- `POST /api/materias` → Criar nova matéria
- `GET /api/materias` → Listar todas as matérias do aluno
- `PUT /api/materias/{id}` → Atualizar nome/descrição
- `DELETE /api/materias/{id}` → Excluir matéria

### **/api/topicos**

- `POST /api/topicos` → Criar novo tópico
- `PATCH /api/topicos/{id}/concluir` → Marcar tópico como concluído
- `DELETE /api/topicos/{id}` → Remover tópico

### **/api/sessoes-estudo**

- `POST /api/sessoes-estudo` → Registrar uma sessão
- `GET /api/sessoes-estudo/materia/{id}` → Listar sessões de uma matéria

---

## 💻 Frontend (Angular)

### **Componentes sugeridos:**

- `login-page` → Tela de login/cadastro `dashboard-page` → Exibe resumo de progresso geral
- `materia-list` → Lista de matérias e progresso
- `materia-detalhe` → Exibe tópicos e sessões de estudo
- `nova-sessao-modal` → Formulário para registrar estudo

### **Funcionalidades:**

- Login e cadastro via API.
- CRUD completo de matérias e tópicos.
- Dashboard mostrando horas estudadas e progresso.
- Componentes com Angular Material e gráficos (Recharts/Chart.js).

---

## 🧩 Tecnologias Utilizadas

| Camada         | Tecnologia              |
| -------------- | ----------------------- |
| Backend        | ASP.NET Core (.NET 8.0) |
| ORM            | NHibernate              |
| Mapeamento     | AutoMapper              |
| Banco de Dados | MySQL                   |
| Frontend       | Angular                 |
| Arquitetura    | DDD                     |
| Testes         | xUnit (Domínio.Testes) |

---

## 🚀 Próximos Passos

1. Criar o projeto base com a estrutura DDD.
2. Implementar as entidades e mapeamentos NHibernate.
3. Criar os DTOs e Services na camada de Aplicação.
4. Expor endpoints REST na API.
5. Implementar autenticação JWT.
6. Criar a interface Angular e conectar ao backend.

---

📄 **Autor:** Hugo Almeida
💡 **Propósito:** Projeto de treinamento full stack (DDD + .NET + Angular)
