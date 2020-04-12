using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Core.Features.Recipes.Queries.Requests;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetAllQuery"/> requests.
    /// </summary>
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<RecipeModel>>
    {
        private readonly IRecipeDomainContext _recipeDomainContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllQueryHandler"/> class.
        /// </summary>
        public GetAllQueryHandler(IRecipeDomainContext recipeDomainContext)
        {
            _recipeDomainContext = recipeDomainContext;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RecipeModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeDomainContext
                .Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .ToListAsync();

            return recipes.Select(RecipeModel.From);
        }
    }
}
