using Autofac;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.WebApi.Infrastructure;

namespace RecipeManager.Host
{
    public class HostDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AppSettingsConnectionStringProvider>()
                .As<IConnectionStringProvider>();

            builder.RegisterModule<WebApiDependencyModule>();
        }
    }
}
