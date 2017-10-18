using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleSolution.WebApp.Controller
{
    public class ConventionResourceController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new {message = "Convention resource GET"});
        }
        
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new { message = "Convention resource POST" });
        }

        public HttpResponseMessage Put()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new { message = "Convention resource PUT" });
        }

        public HttpResponseMessage Delete()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                new { message = "Convention resource DELETE" });
        }
    }
}