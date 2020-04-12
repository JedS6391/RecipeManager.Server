﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Data.Abstract;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Defines base function for all query request handlers.
    /// </summary>
    public abstract class BaseQueryHandler<TRequest, TResponse>
        : IRequestHandler<TRequest, TResponse>
          where TRequest : IRequest<TResponse>
    {
        protected readonly IRecipeDomainContext RecipeDomainContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseQueryHandler{TRequest, TResponse}"/> class.
        /// </summary>
        public BaseQueryHandler(IRecipeDomainContext recipeDomainContext)
        {
            RecipeDomainContext = recipeDomainContext;
        }

        /// <inheritdoc/>
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
