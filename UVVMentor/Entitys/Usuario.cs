using System.Text.RegularExpressions;

namespace UVVMentor.Entitys;

public class Usuario
{
    public virtual int Id { get; set; }
    public virtual string Email { get; set; }
    public virtual string Senha { get; set; }
    public virtual string NomeCompleto { get; set; }
    public virtual DateTime DataCriacao { get; set; }
    public virtual DateTime DataAtualizacao { get; set; }
    public virtual string Telefone { get; set; }
    public virtual string Biografia { get; set; }
    public virtual string Localizacao { get; set; }
    public virtual IList<Agendamento> Agendamentos { get; set; }

    public Usuario()
    {
    }

    public Usuario(string email, string senha, string nomeCompleto)
    {
        //Validação de e-mail
        if (string.IsNullOrWhiteSpace(email) ||
            !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ArgumentException("E-mail inválido.", nameof(email));
        }
        //Validação de senha
        if (string.IsNullOrWhiteSpace(senha) && senha.Length < 6)
        {
            throw new ArgumentException("A senha não pode ser vazia e deve conter pelo menos 6 caracteres.", nameof(senha));
        }

        // Regras extras de senha:
        // - Uma letra maiúscula
        // - Um número
        // - Um caractere especial
        if (!Regex.IsMatch(senha, @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+]).{6,}$"))
        {
            throw new ArgumentException("A senha deve conter ao menos uma letra maiúscula, um número e um caractere especial.", nameof(senha));
        }

        //Validação de nome
        if (string.IsNullOrWhiteSpace(nomeCompleto))
        {
            throw new ArgumentException("O nome completo não pode ser vazio.", nameof(nomeCompleto));
        }

        if (nomeCompleto.Length < 3)
        {
            throw new ArgumentException("O nome completo deve conter pelo menos 3 caracteres.", nameof(nomeCompleto));
        }

        Email = email;
        Senha = senha;
        NomeCompleto = nomeCompleto;
    }

}