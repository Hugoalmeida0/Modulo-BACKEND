namespace UVVMentor.Entitys;

public class Agendamento
{
    public virtual int Id { get; set; }
    public virtual Usuario IdEstudante { get; set; }
    public virtual PerfilMentor IdMentor { get; set; }
    public virtual Disciplina IdDisciplina { get; set; }
    public virtual DateTime DataAgendamento { get; set; } // se preferir separar data/hora, mantenha
    public virtual TimeSpan HoraAgendamento { get; set; } // ou DateTime
    public virtual int Duracao { get; set; }
    public virtual string Status { get; set; }
    public virtual string Objetivo { get; set; }
    public virtual DateTime DataCriacao { get; set; }
    public virtual DateTime DataAtualizacao { get; set; }
    public virtual string MotivoCancelamento { get; set; }
    
    
    public Agendamento()
    {
        
    }
}