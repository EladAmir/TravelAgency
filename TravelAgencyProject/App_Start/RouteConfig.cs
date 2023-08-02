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
               name: "SingUp",
               url: "Login/NewUser",
               defaults: new { controller = "Login", action = "SingUp", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Success",
              url: "Flights/Success",
              defaults: new { controller = "Flights", action = "Booking", id = UrlParameter.Optional }
          );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional, extraparm = UrlParameter.Optional }
            );
        }
    }
}
