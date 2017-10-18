using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace SimpleSolution.Test
{
    public class HttpMethodDispatchingFacts : ResourceTestBase
    {
        

        static async Task<T> ReadAsJsonAsync<T>(HttpResponseMessage resp, T template)
        {
            return JsonConvert.DeserializeAnonymousType(
                await resp.Content.ReadAsStringAsync(),
                template);
        }

        [Theory]
        [InlineData("GET", "Convention resource GET")]
        [InlineData("POST", "Convention resource POST")]
        [InlineData("DELETE", "Convention resource DELETE")]
        [InlineData("PUT", "Convention resource PUT")]
        public async Task should_dispatch_to_correct_method(string method, string expected)
        {
            HttpResponseMessage response = await Client.SendAsync(
                new HttpRequestMessage(new HttpMethod(method), "convention-resource"));

            var payload = await ReadAsJsonAsync(response, new { message = default(string)});

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            Assert.Equal(expected, payload.message);

        }

        [Fact]
        public async Task should_dispatch_to_explicit_http_methods()
        {
            HttpResponseMessage resp = await Client.GetAsync("explicitly-resource");

            Assert.Equal(HttpStatusCode.OK,resp.StatusCode);
        }

        [Theory]
        [InlineData("PUT", "Explicitly resource PUT")]
        [InlineData("POST", "Explicitly resource POST")]
        public async Task should_dispatch_put_or_post_method(string method, string expected)
        {
            HttpResponseMessage response = await Client.SendAsync(
                new HttpRequestMessage(new HttpMethod(method), "explicitly-resource"));
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);

            var payload = await ReadAsJsonAsync(response, new {message = default(string)});
            Assert.Equal(expected, payload.message);
        }
    }
}
