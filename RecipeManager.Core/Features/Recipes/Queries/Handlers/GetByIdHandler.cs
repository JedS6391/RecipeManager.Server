using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Exceptions;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Core.Features.Recipes.Queries.Requests;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetAllQuery"/> requests.
    /// </summary>
    public class GetByIdHandler : BaseQueryHandler<GetByIdQuery, RecipeModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIdHandler"/> class.
        /// </summary>
        public GetByIdHandler(IRecipeDomainContext recipeDomainContext)
            : base(recipeDomainContext)
        {}

        /// <inheritdoc/>
        public override async Task<RecipeModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
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
