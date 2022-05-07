using Autofac;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RecipeManager.Core.Infrastructure;
using RecipeManager.WebApi.Security;

namespace RecipeManager.WebApi.Infrastructure
{
    public class WebApiDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<CoreDependencyModule>();
            
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

            builder
                .RegisterType<AuthorizationScopeAuthorizationHandler>()
                .As<IAuthorizationHandler>()
                .SingleInstance();
        }
    }
}
