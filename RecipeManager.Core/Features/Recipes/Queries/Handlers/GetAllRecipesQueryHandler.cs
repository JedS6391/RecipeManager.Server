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
    /// Handles <see cref="GetAllRecipesQuery"/> requests.
    /// </summary>
    public class GetAllRecipesQueryHandler : BaseQueryHandler<GetAllRecipesQuery, IEnumerable<RecipeModel>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllRecipesQueryHandler"/> class.
        /// </summary>
        public GetAllRecipesQueryHandler(IRecipeDomainContext recipeDomainContext)
            : base(recipeDomainContext)
        {}

        /// <inheritdoc/>
        public override async Task<IEnumerable<RecipeModel>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = await RecipeDomainContext
                .GetRecipesForUser(request.User)
                .ToListAsync();

            return recipes.Select(RecipeModel.From);
        }
    }
}
