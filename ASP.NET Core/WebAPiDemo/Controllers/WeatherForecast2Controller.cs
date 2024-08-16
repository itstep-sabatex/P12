using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using WebAPiDemo.Services;

namespace WebAPiDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastTController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ScopedService scopedService;
        private readonly TransientService transientService;
        private readonly SingletonService singletonService;

        public WeatherForecastTController(ILogger<WeatherForecastController> logger, TransientService transientService, SingletonService singletonService,ScopedService scopedService)
        {
            _logger = logger;
            this.transientService = transientService;
            this.singletonService = singletonService;
            this.scopedService = scopedService;
        }
        public record User(Guid Id,string Name,string Passwor);

        static Dictionary<string, User> users = new Dictionary<string, User> { { "Pedro", new User(new Guid(), "Pedro","12345") } };
        static Dictionary<Guid,string> activeTokens = new Dictionary<Guid,string>();

        
       public  record RegisteredToken(Guid Token,Guid UserId);

        [HttpPost("Login")]
        public IActionResult Login(string userName,string PassWord)
        {
            if (users.ContainsKey(userName))
            {
                if (users[userName].Passwor == PassWord)
                {
                    var token = new Guid();
                    activeTokens.Add(token, userName);
                    return Ok(token);
                }
            }
            return Unauthorized();
        }


        [HttpGet()]
        public IEnumerable<WeatherForecast> Get([FromHeader] Guid token)
        {
            if (activeTokens.ContainsKey(token))
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            }
            else
            {
                throw new Exception("Access denied");
            }
        }

        [HttpPost("demostring")]
        public string GetStr()
        {
            return "Hello World";
        }


    }
}
