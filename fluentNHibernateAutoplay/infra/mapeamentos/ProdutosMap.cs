using FluentNHibernate.Mapping;
using fluentNHibernateAutoplay.Entidades;

namespace fluentNHibernateAutoplay.infra.mapeamentos
{
    public class ProdutosMap : ClassMap<Produto>
    {
        public ProdutosMap()
        {
            Schema("Nome do Schema");
            Table("Nome da tabela a ser mapeada");

            Id(produto => produto.Id).Column("Nome da Coluna do ID");
            Map(produto => produto.Nome).Column("Nome da Coluna do Nome");
            Map(produto => produto.Preco).Column("Nome da Coluna do Preço");
            
        }
    }
}