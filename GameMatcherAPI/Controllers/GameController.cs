using Microsoft.AspNetCore.Mvc;
using GameMatcherAPI.Models;
using GameMatcherAPI.Services;

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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
