namespace UVVMentor.Entitys;

public class Avaliacao
{
    public virtual int Id { get; set; }
    public virtual int Nota { get; set; }
    public virtual string Comentario { get; set; }
    public virtual DateTime DataCriacao { get; set; }
    public virtual Agendamento IdAgendamento { get; set; }
    public virtual Usuario IdEstudante { get; set; }
    public virtual PerfilMentor IdMentor { get; set; }

    public Avaliacao()
    {
    }

}