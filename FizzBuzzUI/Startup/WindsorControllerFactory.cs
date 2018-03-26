namespace FizzBuzzUI.StartUp
{
    using System;

    using System.Web.Mvc;

    using Castle.MicroKernel;

    public class WindsorControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new Exception("No controller found");
            }

            return (IController)this.kernel.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            this.kernel.ReleaseComponent(controller);
        }
    }
}