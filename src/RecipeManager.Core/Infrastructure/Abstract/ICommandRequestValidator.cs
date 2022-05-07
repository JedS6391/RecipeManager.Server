using System.Threading.Tasks;
using MediatR;

namespace RecipeManager.Core.Infrastructure.Abstract
{
    /// <summary>
    /// Defines a validator for a command request.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface ICommandRequestValidator<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task Validate(TRequest request);
    }
}
