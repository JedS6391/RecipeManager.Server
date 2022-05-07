using System.Threading.Tasks;
using RecipeManager.Core.Exceptions;
using RecipeManager.Core.Features.Recipes.Commands.Requests;
using RecipeManager.Core.Features.Recipes.Models.Query;
using RecipeManager.Core.Infrastructure.Abstract;

namespace RecipeManager.Core.Features.Recipes.Commands.Validation
{
    /// <summary>
    /// A command request validator for <see cref="CreateRecipeRequest"/> requests.
    /// </summary>
    public class CreateRecipeCommandRequestValidator
        : ICommandRequestValidator<CreateRecipeRequest, RecipeModel>
    {
        public Task Validate(CreateRecipeRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrWhiteSpace(request.Name))
            {
                ThrowValidationError(ValidationErrors.NameMustBeANonEmptyString);
            }

            return Task.CompletedTask;
        }

        private void ThrowValidationError(params string[] validationErrors)
        {
            throw new ValidationException("Unable to create recipe due to failed validations.", validationErrors);
        }

        private static class ValidationErrors
        {
            public static string NameMustBeANonEmptyString = $"{nameof(CreateRecipeRequest)}:invalid-name";
        }
    }
}
