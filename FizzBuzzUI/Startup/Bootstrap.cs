namespace FizzBuzzUI.StartUp
{
    using System.Web.Mvc;

    using Castle.Windsor;

    public static class Bootstrap
    {
        public static void Start(IWindsorContainer container)
        {
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
        }
    }
}