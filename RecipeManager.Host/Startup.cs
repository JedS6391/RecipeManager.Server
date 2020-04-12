using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace RecipeManager.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var webApiAssembly = Assembly.Load("RecipeManager.WebApi");

            var builder = services.AddControllers();
            
            builder.PartManager.ApplicationParts.Add(new AssemblyPart(webApiAssembly));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<HostDependencyModule>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
        }
    }
}
