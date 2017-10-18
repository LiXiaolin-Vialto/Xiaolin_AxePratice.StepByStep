using System.Web.Http;

namespace SimpleSolution.WebApp
{
    public class Bootstrapper
    {
        public static void Init(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "dispatching by convention",
                "convention-resource",
                new {controller = "ConventionResource" });

            config.Routes.MapHttpRoute(
                "dispatching explicitly",
                "explicitly-resource",
                new {controller = "ExplicitResource"});
        }
    }
}