using System.Web.Mvc;
using System.Web.Routing;
using SocialNetwork1._1.Constraints;

namespace SocialNetwork1._1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "MobileDefault",
                url: "Home/Index/{id}",
                defaults: new { controller = "Value", action = "Index", id = UrlParameter.Optional },//обрабатывать должна web api
                constraints: new { mobileConstraint = new MobileConstraint() }
            );*/

            routes.MapRoute(
                name: "MobileForAll",
                url: "{*catchall}",
                defaults: new { controller = "Home", action = "MobileView"},
                constraints: new { mobileConstraint = new MobileConstraint() }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Muestra", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
