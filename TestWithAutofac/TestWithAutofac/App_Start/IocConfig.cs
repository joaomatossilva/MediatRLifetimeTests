using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace TestWithAutofac
{
    public class IocConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new RegisterTypes());

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}