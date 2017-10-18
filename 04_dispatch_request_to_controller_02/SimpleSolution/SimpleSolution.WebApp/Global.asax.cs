using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace SimpleSolution.WebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            HttpConfiguration httpConfiguration = GlobalConfiguration.Configuration;
            Bootstrapper.Init(httpConfiguration);
        }

    }
}