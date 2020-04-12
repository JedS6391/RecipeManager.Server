using MediatR;
using RecipeManager.Core.Features.Recipes.Models;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    public class CreateRecipeRequest : IRequest<RecipeModel>
    {
        public string Name { get; set;  }
    }
}
