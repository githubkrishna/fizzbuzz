namespace FizzBuzzUI
{
    using System.Web.Mvc;

    using System.Web.Routing;

    using Castle.Windsor;

    using DI;

    using StartUp;

    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container;

        public MvcApplication()
        {
            this.container = new WindsorContainer().Install(new DependencyInstaller());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Bootstrap.Start(this.container);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
