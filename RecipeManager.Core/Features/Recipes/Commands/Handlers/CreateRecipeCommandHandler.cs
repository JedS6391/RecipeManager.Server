using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers
{
    /// <summary>
    /// Handles all <see cref="CreateRecipeRequest"/> requests.
    /// </summary>
    public class CreateRecipeCommandHandler : BaseValidatingCommandHandler<CreateRecipeRequest, RecipeModel>
    {
        public CreateRecipeCommandHandler(
            IRecipeDomainContext recipeDomainContext,
            IEnumerable<ICommandRequestValidator<CreateRecipeRequest, RecipeModel>> commandRequestValidators)
            : base(recipeDomainContext, commandRequestValidators)
        {}

        public override async Task<RecipeModel> DoHandleRequest(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe()
            {
                Name = request.Name,
                Ingredients = new Ingredient[] { },
                Instructions = new Instruction[] { },
                UserId = request.User.Id
            };

            await RecipeDomainContext.Recipes.AddAsync(recipe, cancellationToken);

            await RecipeDomainContext.SaveChangesAsync();

            return RecipeModel.From(recipe);
        }
    }
}
