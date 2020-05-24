using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeManager.Core.Infrastructure;
using RecipeManager.Worker.Workers;

namespace RecipeManager.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule<CoreDependencyModule>();
                    builder.RegisterModule<WorkerDependencyModule>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<RecipeImportWorker>();
                });
    }
}