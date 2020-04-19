using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Data.Abstract;

namespace RecipeManager.Core.Infrastructure.Abstract
{
    /// <summary>
    /// Defines a base set of functionality for command request handlers.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class BaseCommandHandler<TRequest, TResponse>
            : IRequestHandler<TRequest, TResponse>
              where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Gets the recipe domain context.
        /// </summary>
        protected readonly IRecipeDomainContext RecipeDomainContext;

        protected BaseCommandHandler(IRecipeDomainContext recipeDomainContext)
        {
            RecipeDomainContext = recipeDomainContext;
        }

        /// <inheritdoc/>
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
