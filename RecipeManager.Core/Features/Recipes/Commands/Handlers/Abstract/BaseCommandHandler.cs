using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Data.Abstract;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers.Abstract
{
    public abstract class BaseCommandHandler<TRequest, TResponse>
            : IRequestHandler<TRequest, TResponse>
              where TRequest : IRequest<TResponse>
    {
        protected readonly IRecipeDomainContext RecipeDomainContext;

        protected BaseCommandHandler(IRecipeDomainContext recipeDomainContext)
        {
            RecipeDomainContext = recipeDomainContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
