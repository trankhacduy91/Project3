using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eProject3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            

            routes.MapRoute(
                name: "Question Detail",
                url: "question-{id}",
                defaults: new { controller = "Question", action = "QuestionDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "User Detail",
               url: "user-{id}",
               defaults: new { controller = "UserDetail", action = "ViewDetail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Create Account",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Create", action = "User", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
           );

            

            routes.MapRoute(
               name: "Logout",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Logout", action = "Login", id = UrlParameter.Optional }
           );
            
            routes.MapRoute(
                name: "New Question",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Question", action = "NewQuestion", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Update User",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "UserDetail", action = "Update", id = UrlParameter.Optional }
          );



            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "eProject3.Controllers"}
            );
        }
    }
}
