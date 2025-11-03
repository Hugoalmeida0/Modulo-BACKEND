using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fluentNHibernateAutoplay.Entidades
{
    public class Pedido
    {
        public virtual int Id { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual IList<Produto> Produtos { get; set; }


        public Pedido()
        {

        }

        public Pedido(Cliente cliente, IList<Produto> produtos)
        {
            this.Data = DateTime.Now;
            this.Produtos = produtos;
            //this.Cliente = cliente;
        }
    }
}