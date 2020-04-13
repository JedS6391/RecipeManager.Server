using Autofac;
using Autofac.Integration.WebApi;
using MediatR;
using Microsoft.AspNetCore.Http;
using RecipeManager.Core.Infrastructure;
using RecipeManager.WebApi.Security;

namespace RecipeManager.WebApi.Infrastucture
{
    public class WebApiDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<CoreDependencyModule>();

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder
                .RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>();

            builder
                .RegisterType<HttpContextIdentityProvider>()
                .As<IIdentityProvider>();
        }
    }
}
