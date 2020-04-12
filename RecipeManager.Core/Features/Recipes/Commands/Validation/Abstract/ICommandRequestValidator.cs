using System.Threading.Tasks;
using MediatR;

namespace RecipeManager.Core.Features.Recipes.Commands.Validation.Abstract
{
    public interface ICommandRequestValidator<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task Validate(TRequest request);
    }
}
