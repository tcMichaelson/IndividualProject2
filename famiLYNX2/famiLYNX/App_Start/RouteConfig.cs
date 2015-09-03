using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace famiLYNX {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Add Message",
                url: "Messages/Create",
                defaults: new { controller = "Messages", Action = "Create" }

                );

            routes.MapRoute(
                name: "Create Message",
                url: "Conversations/Create",
                defaults: new { controller = "Conversations", Action = "Create" }
                );

            routes.MapRoute(
                name: "Show New Message",
                url: "Familys/ShowNewMessage",
                defaults: new { controller = "Familys", Action = "ShowNewMessage" }
                );

            routes.MapRoute(
                 name: "Member Profile",
                 url: "{userID}",
                 defaults: new { controller = "Login", Action = "Index" }
                 );


            routes.MapRoute(
                name: "Family Page",
                url: "{userID}/{famName}",
                defaults: new { controller = "Familys", Action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
