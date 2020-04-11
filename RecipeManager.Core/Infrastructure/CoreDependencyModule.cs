using Autofac;

namespace RecipeManager.Core.Infrastructure
{
    /// <summary>
    /// Defines the core dependencies.
    /// </summary>
    public class CoreDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Register all request handlers
            builder.RegisterAssemblyTypes(typeof(CoreDependencyModule).Assembly).AsImplementedInterfaces();
        }
    }
}
