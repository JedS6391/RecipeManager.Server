using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeManager.Core.Data.Abstract;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Handlers
{
    public class CreateRecipeHandler : IRequestHandler<CreateRecipeRequest, RecipeModel>
    {
        private readonly IRecipeDomainContext _recipeDomainContext;

        public CreateRecipeHandler(IRecipeDomainContext recipeDomainContext)
        {
            _recipeDomainContext = recipeDomainContext;
        }

        public async Task<RecipeModel> Handle(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            // TODO: Validation
            var recipe = new Recipe()
            {
                Name = request.Name,
                Ingredients = new Ingredient[] { },
                Instructions = new Instruction[] { }
            };

            _recipeDomainContext.Recipes.Add(recipe);

            await _recipeDomainContext.SaveChangesAsync();

            return RecipeModel.From(recipe);
        }
    }
}
