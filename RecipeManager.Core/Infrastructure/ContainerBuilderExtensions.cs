using System.Linq;
using System.Reflection;
using Autofac;
using MediatR;

namespace RecipeManager.Core.Infrastructure
{
    /// <summary>
    /// A set of extensions for <see cref="ContainerBuilder"/> instances.
    /// </summary>
    internal static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Registers all <see cref="IRequestHandler{TRequest, TResponse}"/> implementations using the given <see cref="ContainerBuilder"/>.
        /// </summary>
        /// <param name="builder">A container builder.</param>
        public static void RegisterRequestHandlers(this ContainerBuilder builder)
        {
            var assembly = typeof(CoreDependencyModule).Assembly;
            var classTypes = assembly.ExportedTypes
                .Select(t => t.GetTypeInfo())
                .Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());
                var handlerTypes = interfaces.Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)
                );

                foreach (var handlerType in handlerTypes)
                {
                    System.Console.WriteLine($"Register handler type {handlerType.Name}");
                    builder.RegisterType(handlerType);
                }
            }
        }
    }
}
