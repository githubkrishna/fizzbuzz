namespace FizzBuzzUI
{
    using System.Web.Mvc;

    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FizzBuzz",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "FizzBuzz", action = "Index", id = UrlParameter.Optional });
        }
    }
}
