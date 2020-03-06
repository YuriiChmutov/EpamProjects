using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EShop.WEB
{
    /// <summary>
    /// "/"                 - Lists the first page of products from all categories
    /// "/Page2"            - Lists the specified page, showing items from all categories
    /// "/Phones"           - Shows the first page of items from a specific category
    /// "/Phones/Page2"     - Shows the specified page of items from the specified category
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new
                {
                    controller = "Product", action = "Index",
                    category = (string)null,
                    page = 1
                 });

            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { Controller = "Product", action = "Index" }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

           

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Product", action = "Index", category = (string)null },
                new { page = @"\d+" }
            );

           

            routes.MapRoute(null,
                "{category}",
                new { controller = "Product", action = "Index", page = 1 }
            );


           
            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Product", action = "Index" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}
