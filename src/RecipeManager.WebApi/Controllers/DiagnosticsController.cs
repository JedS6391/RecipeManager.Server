using System;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.Core.Data.Abstract;

namespace RecipeManager.WebApi.Controllers
{
    [ApiController]
    public class DiagnosticsController : ControllerBase
    {
        private readonly IRecipeDomainContext _recipeDomainContext;

        public DiagnosticsController(IRecipeDomainContext recipeDomainContext)
        {
            _recipeDomainContext = recipeDomainContext;
        }

        [HttpGet]
        [Route("api/ping")]
        public string Ping()
        {
            return $"Pong at {DateTime.UtcNow.ToString("o")}";
        }

        [HttpGet]
        [Route("api/health")]
        public string Health()
        {
            return _recipeDomainContext.IsHealthy() ?
             "Health check passed" :
             "Health check failed";
        }        
    }
}
