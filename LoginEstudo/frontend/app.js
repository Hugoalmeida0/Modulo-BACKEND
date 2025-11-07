const API_BASE = 'http://localhost:5119/api/Usuario';

document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('cadastroForm');
    const msg = document.getElementById('message');

    form.addEventListener('submit', async (e) => {
        e.preventDefault();
        msg.textContent = '';

        const nome = document.getElementById('nome').value.trim();
        const email = document.getElementById('email').value.trim();
        const senha = document.getElementById('senha').value;
        const confirma = document.getElementById('confirma').value;

        if (senha !== confirma) {
            msg.style.color = 'crimson';
            msg.textContent = 'As senhas não coincidem.';
            return;
        }

        const payload = { Nome: nome, Email: email, Senha: senha };

        try {
            const res = await fetch(API_BASE, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload)
            });

            if (!res.ok) {
                const text = await res.text();
                msg.style.color = 'crimson';
                msg.textContent = `Erro: ${res.status} - ${text}`;
                return;
            }

            const text = await res.text();
            msg.style.color = 'green';
            msg.textContent = text || 'Usuário cadastrado com sucesso!';
            form.reset();
        } catch (err) {
            msg.style.color = 'crimson';
            msg.textContent = 'Falha na requisição. Verifique se a API está rodando e CORS está habilitado.';
            console.error(err);
        }
    });
});
