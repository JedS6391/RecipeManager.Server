using Microsoft.AspNetCore.Authorization;

namespace RecipeManager.WebApi.Security
{
    public class AuthorizationScopeRequirement : IAuthorizationRequirement
    {
        public const string PolicyName = "AuthorizationScope";
    }
}