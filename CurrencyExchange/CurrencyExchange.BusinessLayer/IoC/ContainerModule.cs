using Autofac;
using CurrencyExchange.BusinessLayer.IoC.Modules;

namespace CurrencyExchange.BusinessLayer.IoC
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
        }
    }
}
