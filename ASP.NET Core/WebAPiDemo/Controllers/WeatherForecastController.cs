using Cafe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using WebAPiDemo.Services;

namespace WebAPiDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ScopedService scopedService;
        private readonly TransientService transientService;
        private readonly SingletonService singletonService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TransientService transientService, SingletonService singletonService,ScopedService scopedService)
        {
            _logger = logger;
            this.transientService = transientService;
            this.singletonService = singletonService;
            this.scopedService = scopedService;
        }

        [HttpGet()]
        [Authorize]
        public IActionResult Get()
        {

            return Unauthorized();
            
            if (true)
            {
                return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray());
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("demostring")]
        public string GetStr([FromBody]Role role, [FromQuery] int state)
        {
            return $"Hello {role}";
        }


    }
}
