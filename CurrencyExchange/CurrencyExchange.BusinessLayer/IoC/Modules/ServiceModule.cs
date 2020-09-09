using Autofac;
using CurrencyExchange.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CurrencyExchange.BusinessLayer.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

        }
    }
}
