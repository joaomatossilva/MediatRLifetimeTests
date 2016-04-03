using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Features.Variance;
using MediatR;

namespace TestWithAutofac
{
    public class RegisterTypes : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = DependencyResolver.Current;
                return t => c.GetService(t);
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = DependencyResolver.Current;
                return t => c.GetServices(t);
            });

            builder.RegisterAssemblyTypes(typeof (RegisterTypes).Assembly)
                .As(t => t.GetInterfaces().Where(v => v.IsClosedTypeOf(typeof (IRequestHandler<,>))))
                .As(t => t.GetInterfaces().Where(v => v.IsClosedTypeOf(typeof (IAsyncRequestHandler<,>))))
                .As(t => t.GetInterfaces().Where(v => v.IsClosedTypeOf(typeof (INotificationHandler<>))))
                .As(t => t.GetInterfaces().Where(v => v.IsClosedTypeOf(typeof (IAsyncNotificationHandler<>))));
        }
    }
}