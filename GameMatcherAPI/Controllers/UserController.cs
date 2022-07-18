using Microsoft.AspNetCore.Mvc;

namespace GameMatcherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Nicolas", "Nick", "Jhon", "Juan", "David", "Mathew", "Balmy", "Jack", "George", "Jason"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<User> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new User
            {
                UserId = Convert.ToUInt64(index),
                Name = Names[Random.Shared.Next(Names.Length)],
                Age = rng.Next(10,80)
            })
            .ToArray();
        }
    }
}