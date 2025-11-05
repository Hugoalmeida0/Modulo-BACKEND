namespace UVVMentor.Entitys;

public class PerfilMentor
{
    public virtual int Id { get; set; }
    public virtual Usuario IdUsuario { get; set; }
    public virtual int AnosExperiencia { get; set; }
    public virtual string Localizacao { get; set; }
    public virtual string Disponibilidade { get; set; }
    public virtual decimal PrecoPorHora { get; set; }
    public virtual decimal AvaliacaoMedia { get; set; }
    public virtual IList<Avaliacao> Notas { get; set; }
    // N:N
    public virtual IList<Disciplina> Disciplinas { get; set; }
    public virtual IList<Agendamento> Agendamentos { get; set; }

    public PerfilMentor()
    {

    }





}