using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LoginEstudo.Entities;

namespace LoginEstudo.Mapper;

public class UsuarioMap : ClassMap<Usuario>
{
    public UsuarioMap()
    {
        Schema("app_login");
        Table("usuarios");

        Not.LazyLoad();

        Id(u => u.Id).Column("id");
        Map(u => u.Nome).Column("nome");
        Map(u => u.Email).Column("email");
        Map(u => u.Senha).Column("senha");
        Map(u => u.DataCriacao).Column("data_criacao");
        Map(u => u.UltimoLogin).Column("ultimo_login");
    }
}