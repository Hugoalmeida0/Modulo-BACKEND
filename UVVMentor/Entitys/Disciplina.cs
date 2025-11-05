namespace UVVMentor.Entitys;

public class Disciplina
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; }
    public virtual IList<Graduacao> Graduacoes { get; set; }
    public virtual IList<PerfilMentor> Mentores { get; set; }
    
    public Disciplina()
    {
        
    }
    
    
    
}