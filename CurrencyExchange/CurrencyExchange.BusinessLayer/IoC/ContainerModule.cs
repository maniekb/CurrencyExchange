using Autofac;
using CurrencyExchange.BusinessLayer.IoC.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.BusinessLayer.IoC
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
        }
    }
}
