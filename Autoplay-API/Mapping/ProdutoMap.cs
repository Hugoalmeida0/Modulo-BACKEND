using Autoplay_API.Models;
using FluentNHibernate.Mapping;

namespace Autoplay_API.infra.mapeamentos;

public class ProdutosMap : ClassMap<Produto>
{
    public ProdutosMap()
    {
        Schema("nhibernate");
        Table("produto");

        Not.LazyLoad();

        Id(produto => produto.Id).Column("id");
        Map(produto => produto.Nome).Column("nome");
        Map(produto => produto.Preco).Column("preco");
        
    }
}