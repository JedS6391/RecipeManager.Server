using System;
using Microsoft.AspNetCore.Mvc;

namespace RecipeManager.WebApi.Controllers
{
    [ApiController]
    public class DiagnosticsController : ControllerBase
    {
        public DiagnosticsController()
        {}

        [HttpGet]
        [Route("api/ping")]
        public string Ping()
        {
            return $"Pong at {DateTime.UtcNow.ToString("o")}";
        }
    }
}
