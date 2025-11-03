using FluentNHibernate.Mapping;
using fluentNHibernateAutoplay.Entidades;

namespace fluentNHibernateAutoplay.infra.mapeamentos
{
    public class ClientesMap : ClassMap<Cliente>
    {
        public ClientesMap()
        {
            Schema("Nome do Schema");
            Table("Nome da tabela a ser mapeada");

            Id(cliente => cliente.Id).Column("Coluna do ID");
            Map(cliente => cliente.Nome).Column("Coluna do Nome");
            Map(cliente => cliente.Email).Column("Coluna do Email");
            Map(cliente => cliente.Senha).Column("Coluna da Senha");
            HasMany(cliente => cliente.Pedidos).KeyColumn("Coluna que representa o ID do cliente, em Pedidos");
        }
    }
}