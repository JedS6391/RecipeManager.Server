using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Exceptions;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="UpdateRecipeRequest"/> requests.
    /// </summary>
    public class UpdateRecipeCommandHandler : BaseValidatingCommandHandler<UpdateRecipeRequest, RecipeModel>
    {
        public UpdateRecipeCommandHandler(
            IRecipeDomainContext recipeDomainContext,
            IEnumerable<ICommandRequestValidator<UpdateRecipeRequest, RecipeModel>> commandRequestValidators)
            : base(recipeDomainContext, commandRequestValidators)
        { }

        public override async Task<RecipeModel> DoHandleRequest(UpdateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = await RecipeDomainContext
                .Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .FirstOrDefaultAsync(r => r.UserId == request.User.Id && r.Id == request.RecipeId);

            if (recipe == null)
            {
                throw new RecipeNotFoundException($"No recipe found [ID = {request.RecipeId}]");
            }

            recipe.Name = request.Name;

            await RecipeDomainContext.SaveChangesAsync();

            return RecipeModel.From(recipe);
        }
    }
}
