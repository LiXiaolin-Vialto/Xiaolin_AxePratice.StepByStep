using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace SimpleSolution.Test
{
    public class HttpMethodDispatchingFacts : ResourceTestBase
    {
        static async Task<T> ReadAsJSON<T>(HttpResponseMessage responseMessage, T template)
        {
            return JsonConvert.DeserializeAnonymousType(
                await responseMessage.Content.ReadAsStringAsync(),
                template);
        }

        [Theory]
        [InlineData("GET","Convention Resource GET")]
        [InlineData("POST","Convention Resource POST")]
        [InlineData("PUT","Convention Resource PUT")]
        [InlineData("DELETE","Convention Resource DELETE")]
        public async Task should_dispatch_to_correct_methods(string method, string expected)
        {
            HttpResponseMessage responseMessage = await Client.SendAsync(
                new HttpRequestMessage(new HttpMethod(method), "convention-resource"));

            Assert.Equal(HttpStatusCode.OK,responseMessage.StatusCode);
            var payload = await ReadAsJSON(responseMessage, new {message = default(string)});
            Assert.Equal(expected,payload.message);
        }

        [Fact]
        public async Task should_dispatch_to_explicit_method()
        {
            HttpResponseMessage responseMessage = await Client.GetAsync("explicitly-resource");

            Assert.Equal(HttpStatusCode.OK,responseMessage.StatusCode);
        }

        [Theory]

        [InlineData("POST", "Explicit resource POST")]
        [InlineData("PUT", "Explicit resource PUT")]
        public async Task should_dispatch_put_and_post_to_one_method(string method, string expected)
        {
            HttpResponseMessage responseMessage = await Client.SendAsync(
                new HttpRequestMessage(new HttpMethod(method), "explicitly-resource"));

            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
            var payload = await ReadAsJSON(responseMessage, new {message = default(string)});
            Assert.Equal(expected,payload.message);
        }
    }
}
