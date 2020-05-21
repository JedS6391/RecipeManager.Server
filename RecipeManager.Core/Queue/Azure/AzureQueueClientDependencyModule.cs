using Autofac;
using RecipeManager.Core.Queue.Abstract;

namespace RecipeManager.Core.Queue.Azure
{
    public class AzureQueueClientDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AzureQueueNameProvider>()
                .As<IQueueNameProvider>();
            
            builder
                .RegisterType<AzureQueueConnectionDetailsProvider>()
                .As<IQueueConnectionDetailsProvider<AzureQueueConnectionDetails>>();
            
            builder
                .RegisterGeneric(typeof(AzureQueueClientFactory<>))
                .As(typeof(IQueueClientFactory<>));
        }
    }
}