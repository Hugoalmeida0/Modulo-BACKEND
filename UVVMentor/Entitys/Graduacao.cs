namespace UVVMentor.Entitys;

public class Graduacao
{
    public virtual string Id { get; set; }
    public virtual string Nome { get; set; }
    public virtual string Descricao { get; set; }
    public virtual DateTime DataCriacao { get; set; }
    public virtual IList<Disciplina> Disciplinas { get; set; }
    public Graduacao()
    {
    }
}