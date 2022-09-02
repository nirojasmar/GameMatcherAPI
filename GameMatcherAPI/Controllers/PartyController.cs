using DnsClient;
using GameMatcherAPI.Models;
using GameMatcherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameMatcherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartyController : ControllerBase
    {
        public PartyDAO _partyDAO;

        public PartyController(PartyDAO partyDAO)
        {
            _partyDAO = partyDAO;
        }

        [HttpGet(Name = "GetPartyList")]
        public async Task<List<Party>> Get() =>
            await _partyDAO.GetListAsync();

        [HttpGet("{id}")]
        public async Task<Party> GetById(string id) =>
            await _partyDAO.GetAsync(id);

        [HttpGet(template: "Game/{game_id}", Name = "PartiesByGame")]
        public async Task<List<Party>?> GetByGame(string game_id) =>
            await _partyDAO.GetListByGameAsync(game_id);

        [HttpGet(template: "User/{user}", Name = "UserParty")]
        public async Task<Party?> GetByUser(string user) =>
            await _partyDAO.GetByPlayerAsync(user);

        [HttpPost]
        public async Task<IActionResult> InsertParty(Party party)
        {
            await _partyDAO.InsertAsync(party);
            return CreatedAtAction(nameof(Get), new { id = party.Id }, party);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParty(string id, Party updatedParty)
        {
            var oldParty = await _partyDAO.GetAsync(id);
            if(oldParty == null)
            {
                return NotFound();
            }

            updatedParty.Id = oldParty.Id;
            await _partyDAO.UpdateAsync(id, updatedParty);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParty(string id)
        {
            if (await _partyDAO.GetAsync(id) == null)
            {
                return NotFound();
            }

            await _partyDAO.DeleteAsync(id);
            return NoContent();
        }
    }
}
