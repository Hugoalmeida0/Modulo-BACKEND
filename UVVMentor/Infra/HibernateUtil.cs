using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using UVVMentor.Infra.Mappers;

namespace UVVMentor.Infra
{
    public class HibernateUtil
    {
        private static ISessionFactory sessionFactory;

        public static NHibernate.ISession GetSession()
        {
            if (sessionFactory == null)
            {
                sessionFactory = Fluently.Configure()
                    .Database(
                        PostgreSQLConfiguration.Standard
                            .ConnectionString(
                                "Host=ep-weathered-star-admxp5hj-pooler.c-2.us-east-1.aws.neon.tech;" +
                                "Database=neondb;" +
                                "Username=neondb_owner;" +
                                "Password=npg_MvT8IKux1JRg;" +
                                "Ssl Mode=Require;" +                       // ✅ Correção de maiúsculas
                                "Trust Server Certificate=true;"            // ✅ Necessário para Neon
                            )
                            .ShowSql()
                            .FormatSql()
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
                    .BuildSessionFactory();
            }

            return sessionFactory.OpenSession();
        }
    }
}
