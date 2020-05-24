using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Data.Extensions;
using RecipeManager.Core.Features.Recipes.Exceptions;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Features.Recipes.Queries.Requests;
using RecipeManager.Core.Infrastructure.Abstract;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Queries.Handlers
{
    /// <summary>
    /// Handles <see cref="GetRecipeImportJobQuery"/> requests.
    /// </summary>
    public class GetRecipeImportJobQueryHandler 
        : BaseQueryHandler<GetRecipeImportJobQuery, RecipeImportJobModel>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="GetRecipeImportJobQueryHandler"/> class.
        /// </summary>
        public GetRecipeImportJobQueryHandler(IRecipeDomainContext recipeDomainContext) 
            : base(recipeDomainContext)
        {}

        /// <inheritdoc/>
        public override async Task<RecipeImportJobModel> Handle(GetRecipeImportJobQuery request, CancellationToken cancellationToken)
        {
            var job = await RecipeDomainContext
                .RecipeImportJobs
                .Include(j => j.ImportedRecipe)
                    .ThenInclude(r => r.Ingredients)
                        .ThenInclude(i => i.Category)
                .Include(j => j.ImportedRecipe)
                    .ThenInclude(r => r.Instructions)
                .Include(j => j.ImportedRecipe)
                    .ThenInclude(r => r.RecipeGroupLinks)
                .ForUser(request.User)
                .FirstOrDefaultAsync(j => j.Id == request.Id);

            return job == null ?
                throw new RecipeImportJobNotFoundException($"No recipe import job found [ID = {request.Id}]") :
                RecipeImportJobModel.From(job);
        }
    }
}