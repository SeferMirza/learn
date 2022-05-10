using Castle.MicroKernel;
using Gazel;
using Gazel.Configuration;
using Gazel.WebService.Interceptors.WebApi;
using System.Linq;
using System.Net;
using System.Web.Http.Filters;

namespace Learn.Hangman.App.Rest.Extensions
{
    public class HttpStatusCodeMappings : IOnStartConfiguration
    {
        public int OnStartOrder => Constants.START_ORDER_DOESNT_MATTER;
        public void OnStart(IKernel kernel)
        {
            var statusCodeExceptionFilter = (HttpStatusCodeExceptionFilter)kernel.ResolveAll<IFilter>().FirstOrDefault(f => f is HttpStatusCodeExceptionFilter);

            if (statusCodeExceptionFilter != null)
            {
                statusCodeExceptionFilter
                    .Map(20705 /*RecordNotFound*/, HttpStatusCode.NotFound)
                ;
            }
        }
    }
}