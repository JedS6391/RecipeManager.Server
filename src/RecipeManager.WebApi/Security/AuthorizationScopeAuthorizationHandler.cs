using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace RecipeManager.WebApi.Security
{
    /// <summary>
    /// Responsible for enforcing that users have access to the scope required for the resource being accessed.
    /// </summary>
    public class AuthorizationScopeAuthorizationHandler: AuthorizationHandler<AuthorizationScopeRequirement>
    {
        private readonly ILogger<AuthorizationScopeAuthorizationHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationScopeAuthorizationHandler" class.
        /// </summary>
        /// <param name="logger">A logger instance used for writing log messages.</param>
        public AuthorizationScopeAuthorizationHandler(ILogger<AuthorizationScopeAuthorizationHandler> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationScopeRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                _logger.LogDebug("No authenticated user - authorization failed.");

                context.Fail();

                return Task.CompletedTask;
            }

            var httpContext = context.Resource as HttpContext;
            var routeEndpoint = httpContext.GetEndpoint() as RouteEndpoint;

            var descriptor = routeEndpoint.Metadata
                .OfType<ControllerActionDescriptor>()
                .SingleOrDefault();

            // We only allow one authorization scope attribute to be specified for each method.
            var authorizationScopeAttribute = descriptor
                .MethodInfo
                .GetCustomAttributes<AuthorizationScopeAttribute>()
                .SingleOrDefault();

            if (authorizationScopeAttribute == null)
            {
                _logger.LogDebug("No authorization scopes defined - authorization failed.");

                context.Fail();

                return Task.CompletedTask;
            }

            if (!authorizationScopeAttribute.Scopes.Any())
            {
                _logger.LogDebug("No authorization scopes required - authorization succeeded.");

                context.Succeed(requirement);

                return Task.CompletedTask;
            }

            _logger.LogDebug("Validating permission for required scopes {Scopes}", authorizationScopeAttribute.Scopes);

            // Extract all the *permissions* claims to build a lookup of permissions.
            var permissionClaims = context.User.FindAll(c => c.Type == "permissions");
            var permissions = new HashSet<string>(permissionClaims.Select(c => c.Value));

            // The user must have permission for all of the required scopes.
            if (authorizationScopeAttribute.Scopes.Any(s => !permissions.Contains(s)))
            {
                _logger.LogDebug("No permission for one of the authorization scopes required - authorization failed.");

                context.Fail(
                    new AuthorizationFailureReason(
                        this,
                        $"No permission for one of the required scopes {string.Join(",", authorizationScopeAttribute.Scopes)}"));

                return Task.CompletedTask;
            }

            _logger.LogDebug("User has permission for authorization scopes required - authorization succeeded.");

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
