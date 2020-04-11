using Autofac;
using RecipeManager.WebApi.Infrastucture;

namespace RecipeManager.Host
{
    public class HostDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<WebApiDependencyModule>();
        }
    }
}
