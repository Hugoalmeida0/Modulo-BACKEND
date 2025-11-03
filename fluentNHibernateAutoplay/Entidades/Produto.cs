using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fluentNHibernateAutoplay.Entidades
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual float Preco { get; set; }
        public Produto()
        {

        }
        
        public Produto(string nome, float preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }
        
        
        
        
    }
}