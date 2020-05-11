using Autofac;
using Microsoft.Extensions.Configuration;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Queue.Azure;

namespace RecipeManager.Worker
{
    public class WorkerDependencyModule : Module
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

                    return new AzureQueueConnectionDetails()
                    {
                        StorageConnectionString = configuration.GetValue<string>("Queue:StorageConnectionString")
                    };
                })
                .SingleInstance();
            
            builder.RegisterModule<AzureQueueClientDependencyModule>();
        }
    }
}