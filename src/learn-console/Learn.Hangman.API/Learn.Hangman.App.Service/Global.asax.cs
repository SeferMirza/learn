using FluentNHibernate.Cfg.Db;
using Gazel.Configuration.Configurers;
using Gazel.Web;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace Learn.Hangman.App.Service
{
    public class Global : ServiceApplication
    {
        protected override DatabaseConfiguration Database(DatabaseConfigurer configure) =>
            configure.Database<MySQLConfiguration, MySQLConnectionStringBuilder>(() =>
                MySQLConfiguration.Standard.Dialect<MySQL5Dialect>().Driver<MySqlDataDriver>()
                , autoCreateSchema: true
                , connectionString: FromConfig<string>("Configuration.Database.ConnectionString")
            );

        protected override AuthenticationFeature Authentication(AuthenticationConfigurer configure) => configure.NoAuthentication();

        protected override AuthorizationFeature Authorization(AuthorizationConfigurer configure) => configure.NoAuthorization();

        protected override AuditOption Audit(AuditConfigurer configure) => configure.Disabled();

        protected override ServiceConfiguration Service(ServiceConfigurer configure) => configure.Routine("https://localhost:44303/service");

        protected override LoggingFeature Logging(LoggingConfigurer configure)
        {
            return configure.Log4Net(initialLevel:Gazel.Logging.LogLevel.Debug);
        }
    }
}