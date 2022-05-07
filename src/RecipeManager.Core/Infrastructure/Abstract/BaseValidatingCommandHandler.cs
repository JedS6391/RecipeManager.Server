using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Data.Abstract;

namespace RecipeManager.Core.Infrastructure.Abstract
{
    /// <summary>
    /// Defines a base set of functionality for command request handlers with validation.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class BaseValidatingCommandHandler<TRequest, TResponse>
        : BaseCommandHandler<TRequest, TResponse>
          where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<ICommandRequestValidator<TRequest, TResponse>> _commandRequestValidators;

        protected BaseValidatingCommandHandler(
            IRecipeDomainContext recipeDomainContext,
            IEnumerable<ICommandRequestValidator<TRequest, TResponse>> commandRequestValidators)
            : base(recipeDomainContext)
        {
            _commandRequestValidators = commandRequestValidators;
        }

        public abstract Task<TResponse> DoHandleRequest(TRequest request, CancellationToken cancellationToken);

        public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            foreach (var commandRequestValidator in _commandRequestValidators)
            {
                await commandRequestValidator.Validate(request);
            }

            return await DoHandleRequest(request, cancellationToken);
        }
    }
}
