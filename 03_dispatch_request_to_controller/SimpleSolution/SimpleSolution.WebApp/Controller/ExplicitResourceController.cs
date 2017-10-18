using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp.Controller
{
    public class ExplicitResourceController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new {message = "Explicit resource GET"});
        }

        [HttpPost]
        [HttpPut]
        public HttpResponseMessage PostOrPut()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new { message = $"Explicit resource {Request.Method.Method}" });
        }

    }
}