using Autofac;
using Autofac.Integration.WebApi;
using MediatR;
using RecipeManager.Core.Infrastructure;

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
        }
    }
}
