using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Data.Extensions;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Features.Recipes.Queries.Requests;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetAllRecipeGroupsQuery"/> requests.
    /// </summary>
    public class GetAllRecipeGroupsQueryHandler 
        : BaseQueryHandler<GetAllRecipeGroupsQuery, IEnumerable<RecipeGroupModel>>
    {
        public GetAllRecipeGroupsQueryHandler(IRecipeDomainContext recipeDomainContext) 
            : base(recipeDomainContext)
        {
        }

        public override async Task<IEnumerable<RecipeGroupModel>> Handle(GetAllRecipeGroupsQuery request, CancellationToken cancellationToken)
        {
            var recipeGroups = await RecipeDomainContext
                .RecipeGroups
                .ForUser(request.User)
                .OrderBy(rg => rg.Name)
                .ToListAsync();

            return recipeGroups.Select(RecipeGroupModel.From);
        }
    }
}