using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginEstudo.Dtos;

public class UsuarioLoginDTO
{
    [Required]
    [StringLength(50, ErrorMessage = "O nome não pode conter mais do que 50 caracteres")]
    public virtual string Nome { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "O e-mail não pode conter mais do que 50 caracteres")]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
    public UsuarioLoginDTO(string nome, string email, string senha)
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

        //Validação de nome
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome completo não pode ser vazio.", nameof(nome));
        }

        if (nome.Length < 3)
        {
            throw new ArgumentException("O nome completo deve conter pelo menos 3 caracteres.", nameof(nome));
        }

        Email = email;
        Senha = senha;
        Nome = nome;

    }

}