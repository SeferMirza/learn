using Castle.MicroKernel;
using Gazel;
using Gazel.Configuration;
using System.Web.Http;

namespace Learn.Hangman.App.Rest.Routes
{
    public class Words : IOnStartConfiguration
    {
        public int OnStartOrder => Constants.START_ORDER_WEB_SERVICE_GENERATION - 1;
        public void OnStart(IKernel kernel)
        {
            var routes = GlobalConfiguration.Configuration.Routes;

            routes.MapHttpRoute(
                name: "GetRandom",
                routeTemplate: "words",
                defaults: new { controller = "words", action = "random" },
                constraints: new { httpMethod = HTTP.GET }
            );
        }
    }
}