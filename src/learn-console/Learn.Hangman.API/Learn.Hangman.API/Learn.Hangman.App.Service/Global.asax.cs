using Gazel.Configuration.Configurers;
using Gazel.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

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