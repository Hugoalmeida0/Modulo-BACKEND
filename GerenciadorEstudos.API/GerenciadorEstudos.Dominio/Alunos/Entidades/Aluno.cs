using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorEstudos.Dominio.Alunos.Entidades;

public class Aluno
{
    public virtual int Id { get; protected set; }
    public virtual string Nome { get; protected set; }
    public virtual string Email { get; protected set; }
    public virtual string Senha { get; protected set; }
    public virtual DateTime DataCriacao { get; protected set; }

    protected Aluno() { }

    public Aluno(string nome, string email, string senha)
    {
        SetNome(nome);
        SetEmail(email);
        SetSenha(senha);
        SetDataCriacao(DateTime.Now);
    }
    public virtual void SetNome(string nome)
    {
        Nome = nome;
    }
    public virtual void SetEmail(string email)
    {
        Email = email;
    }
    public virtual void SetSenha(string senha)
    {
        Senha = senha;
    }
    public virtual void SetDataCriacao(DateTime dataCriacao)
    {
        DataCriacao = dataCriacao;
    }
}