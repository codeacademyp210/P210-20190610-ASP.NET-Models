﻿using System.Web.Mvc;
using System.Web.Routing;

namespace DemoProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    "TestRoute",
            //    "employee/create/heyder/tamerlan/nigar"
            //    new { controller = "Employee", action = "Index", company = "CA" }
            //);

           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
