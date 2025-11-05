namespace UVVMentor.Entitys;

public class Notificacao
{
    public virtual int Id { get; set; }
    public virtual Usuario IdUsuario { get; set; }
    public virtual Agendamento IdAgendamento { get; set; }
    public virtual string Mensagem { get; set; }
    public virtual bool Lido { get; set; }
    public virtual DateTime DataCriacao { get; set; }
    public Notificacao()
    {
    }
}