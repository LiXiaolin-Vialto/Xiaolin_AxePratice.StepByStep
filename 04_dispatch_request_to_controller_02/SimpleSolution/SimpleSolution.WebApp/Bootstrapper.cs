using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                new { controller = "ConventionResource" });

            config.Routes.MapHttpRoute(
                "dispatching explicitly",
                "explicitly-resource",
                new {controller = "ExplicitlyResource"});

            config.Routes.MapHttpRoute(
                "URI get by id query string",
                "uri-resource/queryString",
                new {controller = "UriResource",action = "GetByQueryString"});

            config.Routes.MapHttpRoute(
                "URI get by id",
                "uri-resource/{id}",
                new {controller = "UriResource", action = "GetById"});
        }
    }
}