using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp.Controller
{
    public class UriResourceController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetByQueryString([FromUri] string id)
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new {message = $"Query string id is {id}"});
        }

        [HttpGet]
        public HttpResponseMessage getById(int id)
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new {message = $"Id is {id}"});
        }
       
    }
}