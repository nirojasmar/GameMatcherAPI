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
    }
}
