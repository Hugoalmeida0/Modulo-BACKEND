using FluentNHibernate.Mapping;
using UVVMentor.Entitys;

namespace UVVMentor.Infra.Mappers;

public class UsuarioMap : ClassMap<Usuario>
{
    public UsuarioMap()
    {
        Schema("public");
        Table("usuario");

        Id(p => p.Id).Column("id").GeneratedBy.Sequence("usuario_id_seq");
        Map(p => p.Email).Column("email");
        Map(p => p.Senha).Column("senha");
        Map(p => p.NomeCompleto).Column("nome_completo");
        Map(x => x.DataCriacao)
                .Column("data_criacao")
                .Default("now()")
                .Generated.Insert();
        Map(x => x.DataAtualizacao)
            .Column("data_atualizacao")
            .Default("now()")
            .Generated.Insert();
        Map(p => p.Telefone).Column("telefone");
        Map(p => p.Biografia).Column("biografia");
        Map(p => p.Localizacao).Column("localizacao");
        HasMany(p => p.Agendamentos)
            .KeyColumn("estudante_id");
    }
}