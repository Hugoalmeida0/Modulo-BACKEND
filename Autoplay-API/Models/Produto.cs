using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoplay_API.Models;

public class Produto
{
    public virtual int Id { get; set; }
    public virtual string Nome { get; set; }
    public virtual decimal Preco { get; set; }
    public Produto() { }
    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}