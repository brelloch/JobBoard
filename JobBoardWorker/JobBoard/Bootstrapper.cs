using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using JobBoard.Contracts;
using JobBoard.Services;

namespace JobBoard
{
    public class Bootstrapper
    {
        public static IContainer Run()
        {
            return SetAutofacContainer();
        }

        private static IContainer SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            // REGISTER CONTROLLERS (using assembly scanning)
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // REGISTER SERVICES
            builder.Register(c => new CustomerService(c.Resolve<IGeocodingService>())).As<ICustomerService>().InstancePerLifetimeScope();
            builder.Register(c => new GeocodingService()).As<IGeocodingService>().InstancePerLifetimeScope();

            IContainer container = builder.Build();

            // Set MVC resolver
            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));

            // Set Web API resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }
    }
}