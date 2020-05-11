using MediatR;
using RecipeManager.Domain.Entities;

namespace RecipeManager.Core.Features.Recipes.Commands.Requests
{
    public class ImportRecipeRequest : IRequest
    {
        public string RecipeUrl { get; set; }
        public User User { get; set; }
    }
}