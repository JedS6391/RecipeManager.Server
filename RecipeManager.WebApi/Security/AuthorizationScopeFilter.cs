using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RecipeManager.WebApi.Security
{
    /// <summary>
    /// Responsible for ensuring that users have have the correct permissions for
    /// the scope they are trying to access.
    /// </summary>
    public class AuthorizationScopeFilter : IAuthorizationFilter
    {
        private const string AuthenticationScheme = "Bearer";

        private readonly string[] _scopes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationScopeFilter"/> class.
        /// </summary>
        /// <param name="scopes">The scopes the filter will authorize access for.</param>
        public AuthorizationScopeFilter(string[] scopes)
        {
            _scopes = scopes;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_scopes.Any())
            {
                // No scopes means no permissions are required.
                return;
            }

            var claimsPrincipal = context.HttpContext.User;

            // Extract all the *permissions* claims to build a lookup of permissions.
            var permissionClaims = claimsPrincipal.FindAll(c => c.Type == "permissions");
            var permissions = new HashSet<string>(permissionClaims.Select(c => c.Value));

            if (_scopes.Any(s => !permissions.Contains(s)))
            {
                context.Result = new RequiredScopesForbiddenResult(_scopes);
            }
        }

        /// <summary>
        /// Defines a custom forbidden result that details the required scopes.
        /// </summary>
        internal class RequiredScopesForbiddenResult : JsonResult
        {
            public RequiredScopesForbiddenResult(string[] scopes)
                : base(new RequiredScopesError(scopes))
            {
                StatusCode = StatusCodes.Status403Forbidden;
            }

            /// <summary>
            /// Defines the details of a required scopes error.
            /// </summary>
            internal class RequiredScopesError
            {
                public string ErrorDescription { get; private set; }
                public string[] RequiredScopes { get; private set; }

                public RequiredScopesError(string[] scopes)
                {
                    ErrorDescription = "The authenticated user is missing one or more of the required scopes";
                    RequiredScopes = scopes;
                }
            }
        }
    }
}
