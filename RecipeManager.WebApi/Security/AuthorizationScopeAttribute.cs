using System;

namespace RecipeManager.WebApi.Security
{
    /// <summary>
    /// Defines the scopes required to access a particular API resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizationScopeAttribute : Attribute
    {
        public string[] Scopes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationScopeAttribute" class.
        /// </summary>
        /// <param name="scopes">The scopes required.</param>
        public AuthorizationScopeAttribute(params string[] scopes)
        {
            Scopes = scopes;
        }
    }
}
