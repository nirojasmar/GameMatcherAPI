using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public interface IPartyDataService
    {
        List<Party> GetPartyList();
        Party GetPartyById(ObjectId id);
    }
}
