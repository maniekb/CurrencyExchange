using Autofac;
using CurrencyExchange.BusinessLayer.Repositories;
using CurrencyExchange.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CurrencyExchange.BusinessLayer.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

        }
    }
}