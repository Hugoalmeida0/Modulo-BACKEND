using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using fluentNHibernateAutoplay.Entidades;

namespace fluentNHibernateAutoplay.infra.mapeamentos
{
    public class PedidosMap : ClassMap<Pedido>
    {
        public PedidosMap()
        {
            Schema("Nome do Schema");
            Table("Nome da tabela a ser mapeada");

            Id(pedido => pedido.Id).Column("Nome da Coluna do ID"); //Id()... Usado para mapear o ID
            Map(pedido => pedido.Data).Column("Nome da Coluna da data"); //Map()... Usado para mapear colunas comuns
            References(pedido => pedido.Cliente).Column("Nome da Coluna da FK"); //References()... Usado para mapear chaves estrangeiras
            HasManyToMany(pedido => pedido.Produtos) //HasManyToMany()... Usado para mapear uma relação N:N
                .Table("Nome da tabela N:N criada")
                .ParentKeyColumn("Coluna do ID do dono (Pedido nesse caso)")
                .ChildKeyColumn("Coluna do ID da outra parte da relação N:N (Produto no caso)")
                .Cascade.All(); //Se apagar um dos dados (Ou Pedido ou Produto), todas as informações sobre ele caem em cascata
        }
    }
}