using Gazel.Configuration.Configurers;
using Gazel.Service;
using Gazel.Web;
using Gazel.WebService;
using Routine;
using System;
using System.Net.Http;

namespace Learn.Hangman.App.Rest
{
    public class Global : WebServiceApplication
    {
        protected override ServiceClientConfiguration ServiceClient(ServiceClientConfigurer configure)
        {
            return configure.Routine("https://localhost:44303/service");
        }

        protected override HttpHeaderConfiguration HttpHeader(HttpHeaderConfigurer configure)
        {
            return configure.Custom(c => c
                .RequestHeader("Accept-Language", Header.LanguageCode, header => header.Before(","))
            );

        }
        protected override CorsOption Cors(CorsConfigurer configure)
        {
            return configure.Enabled(
                allowOrigin: "*",
                allowMethods: new[]
                {
                    HttpMethod.Get,
                    HttpMethod.Delete,
                    HttpMethod.Post,
                    HttpMethod.Put,
                    HttpMethod.Options
                },
                allowHeaders: new[]{
                    "Content-Type",
                    "Authorization",
                    "Accept-Language"
            });
        }
        protected override WebServiceConfiguration WebService(WebServiceConfigurer configure) => configure.Rest();

        protected override LoggingFeature Logging(LoggingConfigurer configure)
        {
            return configure.Log4Net(Gazel.Logging.LogLevel.Debug);
        }
    }
}
