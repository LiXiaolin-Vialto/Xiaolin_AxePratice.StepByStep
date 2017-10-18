using System.Web.Http;

namespace SimpleSolution.WebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            HttpConfiguration httpConfiguration = GlobalConfiguration.Configuration;
            BootStrapper.Init(httpConfiguration);
        }
    }
}