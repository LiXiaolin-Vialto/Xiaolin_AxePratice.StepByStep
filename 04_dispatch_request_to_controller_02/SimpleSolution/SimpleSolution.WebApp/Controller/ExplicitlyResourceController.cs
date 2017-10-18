using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp.Controller
{
    public class ExplicitlyResourceController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new {message = "Explicitly resource GET"});
        }

        [HttpPost]
        [HttpPut]
        public HttpResponseMessage PostOrPut([FromBody]string value)
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new { message = $"Explicitly resource {Request.Method.Method}" });
        }

    }
}