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
            return configure.Routine("http://localhost:6161/service");
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
        protected override WebServiceConfiguration WebService(WebServiceConfigurer configure)
        {
            return configure.Rest(
                rootPath: "/",
                namingStyle: WebServiceConfiguration.NamingStyle.camelCase,
                exceptionBodyFunc: ex => new CodeMessage(ex)
            );
        }

        private class CodeMessage : IServiceResultData
        {
            public int code { get; private set; }
            public string message { get; private set; }

            public CodeMessage(Exception exception)
            {
                code = ResultCodeBlocks.Gazel.Fatal();
                message = exception.Message;
            }

            void IServiceResultData.SetResultStatus(int resultCode, string resultMessage)
            {
                code = resultCode;
                message = resultMessage;
            }

            int IServiceResultData.ResultCode => code;
            string IServiceResultData.ResultMessage => message;
        }
    }
}
