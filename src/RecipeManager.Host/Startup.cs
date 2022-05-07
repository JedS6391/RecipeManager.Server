using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeManager.WebApi.Infrastructure.ExceptionHandling;
using RecipeManager.WebApi.Security;

namespace RecipeManager.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var webApiAssembly = Assembly.Load("RecipeManager.WebApi");

            var builder = services.AddControllers(options =>
            {
                options.Filters.Add(new ValidationExceptionFilter());
                options.Filters.Add(new NotFoundExceptionFilter());
            });
            
            builder.PartManager.ApplicationParts.Add(new AssemblyPart(webApiAssembly));

            builder.AddControllersAsServices();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    AuthorizationScopeRequirement.PolicyName,
                    policy => policy.Requirements.Add(new AuthorizationScopeRequirement()));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration.GetValue<string>("Authentication:Authority");
                options.Audience = Configuration.GetValue<string>("Authentication:Audience");
            });

            services.AddCors();
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

            app
                .UseAuthentication()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseCors(builder =>
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin())
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
