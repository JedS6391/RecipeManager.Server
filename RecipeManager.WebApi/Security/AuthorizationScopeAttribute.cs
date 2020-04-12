using Microsoft.AspNetCore.Mvc;

namespace RecipeManager.WebApi.Security
{
    /// <summary>
    /// Defines the permissions required to access a particular scope.
    /// </summary>
    public class AuthorizationScopeAttribute : TypeFilterAttribute
    {
        public AuthorizationScopeAttribute(params string[] scopes)
            : base(typeof(AuthorizationScopeFilter))
        {
            Arguments = new object[] { scopes };
        }
    }
}
