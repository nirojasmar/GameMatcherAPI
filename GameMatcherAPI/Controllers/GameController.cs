using Microsoft.AspNetCore.Mvc;
using GameMatcherAPI.Models;
using GameMatcherAPI.Services;
using Serilog;

namespace GameMatcherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameDAO _gameDAO;

        public GameController(GameDAO gameDAO)
        {
            _gameDAO = gameDAO;
        }

        // GET: api/<GameController>
        [HttpGet(Name = "GetGameList")]
        public async Task<List<Game>> Get() =>
            await _gameDAO.GetAsync();

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public async Task<Game> Get(string id) =>
            await _gameDAO.GetGameById(id);

        // POST api/<GameController>
        [HttpPost]
        public async Task<IActionResult> CreateGame(Game game)
        {
            await _gameDAO.InsertGame(game);
            return CreatedAtAction(nameof(Get), new { id = game.Name }, game);
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(string id, Game updatedGame)
        {
            var game = await _gameDAO.GetGameById(id);
            if (game == null)
            {
                Log.Error("User with id {id} Not Found, Aborting...");
                return NotFound();
            }
            updatedGame.Name = game.Name;

            await _gameDAO.UpdateGame(id, updatedGame);
            return NoContent();
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(string id, Game deletedGame)
        {
            var game = await _gameDAO.GetGameById(id);
            if (game == null)
            {
                Log.Error("User with id {id} Not Found, Aborting...");
                return NotFound();
            }
            deletedGame.Name = game.Name;

            await _gameDAO.UpdateGame(id, deletedGame);
            return NoContent();
        }
    }
}
