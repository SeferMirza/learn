using Gazel.Configuration.Configurers;
using Gazel.Web;
using System;

namespace Learn.Hangman.App.Service
{
    public class Global : ServiceApplication
    {
        protected override DatabaseConfiguration Database(DatabaseConfigurer configure)
        {
            throw new NotImplementedException();
        }

        protected override ServiceConfiguration Service(ServiceConfigurer configure)
        {
            throw new NotImplementedException();
        }
    }
}