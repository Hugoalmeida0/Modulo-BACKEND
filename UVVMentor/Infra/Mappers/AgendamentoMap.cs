using FluentNHibernate.Mapping;
using UVVMentor.Entitys;

namespace UVVMentor.Infra.Mappers;

public class AgendamentoMap : ClassMap<Agendamento>
{
    public AgendamentoMap()
    {
        Schema("public");
        Table("agendamento");

        Id(a => a.Id).Column("id").GeneratedBy.Sequence("agendamento_id_seq");
        Map(a => a.DataAgendamento).Column("data_agendamento");
        Map(a => a.HoraAgendamento).Column("hora_agendamento");
        Map(a => a.Duracao).Column("duracao").Default("60");
        Map(a => a.Status).Column("status").Default("pending");
        Map(a => a.Objetivo).Column("objetivo");
        Map(a => a.MotivoCancelamento).Column("motivo_cancelamento");
        Map(a => a.DataCriacao)
            .Column("data_criacao")
            .Default("now()")
            .Generated.Insert();
        Map(a => a.DataAtualizacao)
            .Column("data_atualizacao")
            .Default("now()")
            .Generated.Insert();
        References(a => a.IdEstudante).Column("estudante_id");
        References(a => a.IdMentor).Column("mentor_usuario_id");
        References(a => a.IdDisciplina).Column("disciplina_id");
    }
}