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

        [HttpGet("{id}")]
        public async Task<User?> GetUserById(string id) =>
            await _userDAO.GetByIdAsync(id);

        [HttpGet(template: "UserGame/{id}", Name = "GetUserGame")]
        public async Task<List<UserGame>> GetUserGamesByName(string id) =>
            await _userDAO.GetUserGamesAsync(id);

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userDAO.InsertAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Name }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var user = await _userDAO.GetByIdAsync(id);

            if(user == null) { return NotFound(); }
            updatedUser.Name = user.Name;

            await _userDAO.UpdateAsync(id, updatedUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userDAO.GetByIdAsync(id);
            if(user == null) { return NotFound(); }

            await _userDAO.DeleteAsync(id);
            return NoContent();
        }
    }
}