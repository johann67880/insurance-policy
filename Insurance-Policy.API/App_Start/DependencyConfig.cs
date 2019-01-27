using Autofac;
using Autofac.Integration.WebApi;
using Insurance_Policy.Domain.Entities;
using Insurance_Policy.Domain.Interfaces;
using Insurance_Policy.Infrastructure.Context;
using Insurance_Policy.Infrastructure.Repositories;
using Insurance_Policy.Services.Interfaces;
using Insurance_Policy.Services.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            //Services
            builder.RegisterType<CoverageTypeService>().As<ICoverageTypeService<CoverageType>>();
            builder.RegisterType<RiskTypeService>().As<IRiskTypeService<RiskType>>();
            builder.RegisterType<CustomerService>().As<ICustomerService<Customer>>();
            builder.RegisterType<InsuranceService>().As<IInsuranceService<Insurance>>();
            builder.RegisterType<InsuranceByCustomerService>().As<IInsuranceByCustomerService<InsuranceByCustomer>>();

            //Repositories
            builder.RegisterType<CoverageTypeRepository>().As<ICoverageTypeRepository>();
            builder.RegisterType<RiskTypeRepository>().As<IRiskTypeRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<InsuranceRepository>().As<IInsuranceRepository>();
            builder.RegisterType<InsuranceByCustomerRepository>().As<IInsuranceByCustomerRepository>();

            string connectionString = ConfigurationManager.ConnectionStrings["InsuranceContextConnectionString"].ConnectionString;
            builder.RegisterType<InsuranceContext>().WithParameter("connectionString", connectionString);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            IContainer container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}