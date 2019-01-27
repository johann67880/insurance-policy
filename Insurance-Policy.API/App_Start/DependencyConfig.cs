using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Insurance_Policy.API.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<TimeReportFilteringService>().As<ITimeReportFilteringService>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            IContainer container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}