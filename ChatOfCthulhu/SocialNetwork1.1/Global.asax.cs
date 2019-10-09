using SocialNetwork1._1.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace SocialNetwork1._1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<ApplicationContext>(new AppDbInitializer());

            /*DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("IE8")
            {
                ContextCondition = (context => context.Request.UserAgent.Contains("MSIE 8"))
            });*/

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
