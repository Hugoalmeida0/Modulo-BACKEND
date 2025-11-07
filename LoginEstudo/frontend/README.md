# Frontend de teste - Cadastro

Arquivos para testar o endpoint de cadastro da API.

Como usar

1. Garanta que a API esteja rodando (por padrão este projeto lança em http://localhost:5119).
2. Abra o arquivo `frontend/index.html` em um navegador (duplo clique ou "Open File").
3. Preencha o formulário e clique em "Criar Conta".

Observações

- O backend espera um POST em `http://localhost:5119/api/Usuario` com um JSON contendo as propriedades: `Nome`, `Email` e `Senha`.
- Se ocorrer erro de CORS, habilite CORS na API. Exemplo mínimo no `Program.cs` antes de MapControllers():

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

app.UseCors("AllowLocalhost");
```

Depois reinicie a API e tente novamente.
