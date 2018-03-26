namespace FizzBuzzUI.DI
{
    using System.Web.Mvc;

    using Castle.MicroKernel.Registration;

    using Castle.MicroKernel.Resolvers.SpecializedResolvers;

    using Castle.MicroKernel.SubSystems.Configuration;

    using Castle.Windsor;

    using FizzBuzzServices;

    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));

            container.Register(
                Classes.FromAssemblyNamed("FizzBuzzUI").BasedOn<IController>().LifestyleTransient(),
                Component.For<IFizzBuzzProvider>().ImplementedBy<FizzBuzzProvider>().LifestyleTransient(),
                Component.For<IFizzBuzzDescriptionProvider>().ImplementedBy<FizzBuzzDescriptionProvider>().LifestyleTransient(),
                Component.For<IDivisibleBy>().ImplementedBy<DivisibleByThree>().LifestyleTransient(),
                Component.For<IDivisibleBy>().ImplementedBy<DivisibleByFive>().LifestyleTransient());
        }
    }
}