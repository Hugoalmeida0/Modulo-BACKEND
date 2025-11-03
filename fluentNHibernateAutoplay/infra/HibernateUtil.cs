using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using fluentNHibernateAutoplay.infra.mapeamentos;
using NHibernate;

namespace fluentNHibernateAutoplay.infra
{
    public class HibernateUtil
    {
        public static ISessionFactory sessionFactory;

        public static ISession getSession()
        {
            sessionFactory = Fluently.Configure().Database(
                MySQLConfiguration.Standard.ConnectionString("Server=localhost;Port=3306;Database=nhibernate;Uid=root;Pwd=Autoglass@2020") //Dados para conexão ao banco
                    .ShowSql() //Exibir no terminal a query utilizada ao rodar o cod
                    .FormatSql()) //Exibir no terminal a query utilizada ao rodar o cod
                    .Mappings(m => { m.FluentMappings.AddFromAssemblyOf<ClientesMap>(); })
                    .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}