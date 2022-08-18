using GameMatcherAPI.Models;
using GameMatcherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameMatcherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDAO _userDAO;

        private readonly ILogger<UserController> _logger;

        public UserController(UserDAO userDAO, ILogger<UserController> logger)
        {
            _userDAO = userDAO;
            _logger = logger;
        }

        [HttpGet(Name = "GetUserList")]
        public async Task<List<User>> Get() =>
            await _userDAO.GetAsync();
    }
}