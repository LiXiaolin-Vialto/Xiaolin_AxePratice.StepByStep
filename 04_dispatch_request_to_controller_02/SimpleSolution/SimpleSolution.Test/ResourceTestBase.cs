using System;
using System.Net.Http;
using System.Web.Http;
using SimpleSolution.WebApp;

namespace SimpleSolution.Test
{
    public class ResourceTestBase : IDisposable
    {
        readonly HttpServer httpServer;
        static readonly Uri WebUri = new Uri("http://www.baidu.com");
        
        protected HttpClient Client { get; }

        public ResourceTestBase()
        {
            httpServer = CreaHttpServer();
            Client = CreateHttpClient(httpServer);
        }

        public HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            return  new HttpClient(handler)
            {
                BaseAddress = WebUri
            };
        }

        public HttpServer CreaHttpServer()
        {
            var config = new HttpConfiguration();
            Bootstrapper.Init(config);

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
