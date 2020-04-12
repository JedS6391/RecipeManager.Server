using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Exceptions;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Core.Features.Recipes.Queries.Handlers.Abstract;
using RecipeManager.Core.Features.Recipes.Queries.Requests;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetRecipeByIdQuery"/> requests.
    /// </summary>
    public class GetRecipeByIdQueryHandler : BaseQueryHandler<GetRecipeByIdQuery, RecipeModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRecipeByIdQueryHandler"/> class.
        /// </summary>
        public GetRecipeByIdQueryHandler(IRecipeDomainContext recipeDomainContext)
            : base(recipeDomainContext)
        {}

        /// <inheritdoc/>
        public override async Task<RecipeModel> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var recipe = await RecipeDomainContext
                .Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .FirstOrDefaultAsync(r => r.Id == request.Id);

            return recipe == null ?
                throw new RecipeNotFoundException($"No recipe found [ID = {request.Id}]") :
                RecipeModel.From(recipe);
        }
    }
}
