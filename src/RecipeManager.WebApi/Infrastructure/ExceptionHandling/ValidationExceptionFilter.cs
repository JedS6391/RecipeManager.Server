using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecipeManager.Core.Exceptions;

namespace RecipeManager.WebApi.Infrastructure.ExceptionHandling
{
    public class ValidationExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.Result = new ValidationErrorBadRequestResult(context.Exception as ValidationException);

                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do nothing.
        }

        internal class ValidationErrorBadRequestResult : JsonResult
        {
            public ValidationErrorBadRequestResult(ValidationException validationException)
                : base(new ValidationError(validationException.Message, validationException.ValidationErrors))
            {
                StatusCode = StatusCodes.Status400BadRequest;
            }

            internal class ValidationError
            {
                public string ErrorDescription { get; private set; }
                public string[] ValidationErrors { get; private set; }

                public ValidationError(string errorDescription, string[] validationErrors)
                {
                    ErrorDescription = errorDescription;
                    ValidationErrors = validationErrors;
                }
            }
        }
    }
}
