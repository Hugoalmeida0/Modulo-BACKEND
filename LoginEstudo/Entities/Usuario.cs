namespace LoginEstudo.Entities;

public class Usuario
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime UltimoLogin { get; set; }
    public Usuario() { }
}