namespace UVVMentor.Entitys;

public class Mensagem
{
    public virtual int Id { get; set; }
    public virtual Agendamento IdAgendamento { get; set; }
    public virtual Usuario Remetente { get; set; }
    public virtual string Conteudo { get; set; }
    public virtual DateTime DataCriacao { get; set; }
    public Mensagem()
    {
    }
}