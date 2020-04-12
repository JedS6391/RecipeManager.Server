using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecipeManager.Core.Exceptions;

namespace RecipeManager.WebApi.Infrastucture.ExceptionHandling
{
    public class NotFoundExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.Result = new NotFoundErrorNotFoundResult(context.Exception as NotFoundException);

                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do nothing.
        }

        internal class NotFoundErrorNotFoundResult : JsonResult
        {
            public NotFoundErrorNotFoundResult(NotFoundException notFoundException)
                : base(new NotFoundError(notFoundException.Message, notFoundException.EntityType))
            {
                StatusCode = StatusCodes.Status404NotFound;
            }

            internal class NotFoundError
            {
                public string ErrorDescription { get; private set; }
                public string EntityType { get; private set; }

                public NotFoundError(string errorDescription, string entityType)
                {
                    ErrorDescription = errorDescription;
                    EntityType = entityType;
                }
            }
        }
    }
}
