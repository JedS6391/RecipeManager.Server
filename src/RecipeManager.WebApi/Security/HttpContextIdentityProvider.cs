using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using RecipeManager.Core.Infrastructure;
using RecipeManager.Domain.Entities;

namespace RecipeManager.WebApi.Security
{
    public class HttpContextIdentityProvider : IIdentityProvider
    {
        private const string AudienceClaimType = "aud";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextIdentityProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User Current
        {
            get
            {
                if (_httpContextAccessor.HttpContext.User != null)
                {
                    var user = _httpContextAccessor.HttpContext.User;
                    var subjectClaim = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                    var audienceClaim = user.FindFirst(c => c.Type == AudienceClaimType);

                    // User ID is a composite of the audience and subject.
                    return new User($"{audienceClaim.Value}-{subjectClaim.Value}");
                }

                // TODO
                throw new System.Exception();
            }
        }
    }
}
