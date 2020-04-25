using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Features.Recipes.Queries.Requests;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetAllIngredientCategoriesQuery"/> requests.
    /// </summary>
    public class GetAllIngredientCategoriesQueryHandler 
        : BaseQueryHandler<GetAllIngredientCategoriesQuery, IEnumerable<IngredientCategoryModel>>
    {
        public GetAllIngredientCategoriesQueryHandler(IRecipeDomainContext recipeDomainContext) 
            : base(recipeDomainContext)
        {
        }

        public override async Task<IEnumerable<IngredientCategoryModel>> Handle(GetAllIngredientCategoriesQuery request, CancellationToken cancellationToken)
        {
            var ingredientCategories = await RecipeDomainContext
                .IngredientCategories
                .Where(ic => ic.UserId == request.User.Id)
                .ToListAsync();

            return ingredientCategories.Select(IngredientCategoryModel.From);
        }
    }
}