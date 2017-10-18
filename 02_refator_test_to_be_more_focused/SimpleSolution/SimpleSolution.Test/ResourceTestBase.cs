using System;
using System.Net.Http;
using System.Web.Http;
using SimpleSolution.WebApp;

namespace SimpleSolution.Test
{
   public class ResourceTestBase : IDisposable
    {
        readonly HttpServer httpServer;
        static readonly Uri WebAppUri = new Uri("http://www.baidu.com");

        protected HttpClient Client {get;}

        public ResourceTestBase()
        {
            httpServer = createHttpServer();
            Client = createHttpClient(httpServer);
        }

        static HttpClient createHttpClient(HttpMessageHandler handler)
        {
            return new HttpClient(handler)
            {
                BaseAddress = WebAppUri
            };
        }

        static HttpServer createHttpServer()
        {
            var config = new HttpConfiguration();
            BootStrapper.Init(config);

            var httpServer = new HttpServer(config);
            return httpServer;
        }
        public void Dispose()
        {
            httpServer?.Dispose();
            Client?.Dispose();
        }
    }
}
