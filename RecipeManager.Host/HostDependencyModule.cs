using Autofac;
using Microsoft.Extensions.Configuration;
using RecipeManager.Core.Configuration;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.WebApi.Infrastucture;

namespace RecipeManager.Host
{
    public class HostDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AppSettingsConnectionStringProvider>()
                .As<IConnectionStringProvider>();

            builder
                .Register(c =>
                {
                    var configuration = c.Resolve<IConfiguration>();

                    return new AuthenticationConfiguration()
                    {
                        Authority = configuration.GetValue<string>("Authentication:Authority"),
                        Audience = configuration.GetValue<string>("Authentication:Audience")
                    };
                })
                .SingleInstance();

            builder.RegisterModule<WebApiDependencyModule>();
        }
    }
}
