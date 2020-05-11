using Autofac;
using RecipeManager.Core.Data;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Services;
using RecipeManager.Core.Features.Recipes.Services.Abstract;

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

            builder
                .RegisterType<RecipeDomainContext>()
                .As<IRecipeDomainContext>();

            builder
                .RegisterType<RecipeImporterService>()
                .As<IRecipeImporterService>();
            
            // Register all request handlers in this assembly. 
            builder
                .RegisterAssemblyTypes(typeof(CoreDependencyModule).Assembly)
                .AsImplementedInterfaces();
        }
    }
}
