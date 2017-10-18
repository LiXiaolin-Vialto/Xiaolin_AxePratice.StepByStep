using System.Web.Http;

namespace SimpleSolution.WebApp
{
    public class BootStrapper
    {
        public static void Init(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                "message",
                "message",
                new {controller = "Message"});
        }
    }
}