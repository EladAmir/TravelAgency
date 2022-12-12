using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelAgencyProject
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Login",
                url: "",
                defaults: new { controller = "Login", action = "ShowLoginPage", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "LoginPage",
                url: "Login/LoginPage",
                defaults: new { controller = "Login", action = "Submit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NewUser",
                url: "Login/NewUser",
                defaults: new { controller = "Login", action = "AddUser", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Enter",
                url: "Login/EnterNewUser",
                defaults: new { controller = "Login", action = "EnterNewUser", id = UrlParameter.Optional }
            );

             routes.MapRoute(
                name: "Success",
                url: "Login/Success",
                defaults: new { controller = "Login", action = "Submit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
