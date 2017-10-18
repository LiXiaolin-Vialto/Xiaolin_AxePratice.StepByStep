using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp.Controller
{
    public class ConventionResourceController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new {message = "Convention Resource GET"});
        }

        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new {message = "Convention Resource POST"});
        }
        public HttpResponseMessage Delete()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new { message = "Convention Resource DELETE" });
        }
        public HttpResponseMessage Put()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new { message = "Convention Resource PUT" });
        }
    }
}