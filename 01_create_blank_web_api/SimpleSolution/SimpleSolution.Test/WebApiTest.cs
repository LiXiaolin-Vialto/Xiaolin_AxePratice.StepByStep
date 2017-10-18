using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SimpleSolution.WebApp;
using Xunit;

namespace SimpleSolution.Test
{
    public class WebApiTest
    {
        [Fact]
        public async Task should_get_hello()
        {
            var config = new HttpConfiguration();
            Bootstrapper.Init(config);

            var httpServer = new HttpServer(config);

            var client = new HttpClient(httpServer)
            {
                BaseAddress = new Uri("http://www.baidu.com")
            };

            HttpResponseMessage response = await client.GetAsync("http://www.baidu.com/message");

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            string content = await response.Content.ReadAsStringAsync();
            var payload = JsonConvert.DeserializeAnonymousType(content, new { message = default(string)});
            Assert.Equal("hello world!",payload.message);

        }
    }
}
