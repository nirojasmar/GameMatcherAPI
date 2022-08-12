using GameMatcherAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameMatcherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        // Testing ONLY
        [HttpGet(Name = "GetUser")]
        public IEnumerable<User> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new User(Names[Random.Shared.Next(Names.Length)])
            {
                Age = rng.Next(10,80),
                Rating = new Rating(rng.Next(1, 5))
            })
            .ToArray();
        }
    }
}