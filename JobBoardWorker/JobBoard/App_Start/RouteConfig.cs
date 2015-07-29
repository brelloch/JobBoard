using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JobBoard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // We only want the javascript tests to be runable while in debug mode
#if DEBUG
            routes.MapRoute(
                "JavascriptTests",
                "Jasmine",
                new { controller = "Jasmine", action = "Index" }
            );
#endif

            // It doesn't matter what route you hit you are going to the angularjs app
            routes.MapRoute(
                "Default",
                "{*url}",
                new { controller = "Home", action = "Index" }
            );

        }
    }
}
