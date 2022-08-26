using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public interface IPartyDataService
    {
        Task<List<Party>> GetListAsync();
        Task<List<Party>> GetListByGameAsync(string game);
        Task<Party> GetByPlayerAsync(string user);
        Task<Party> GetAsync(string id);
        Task InsertAsync(Party party);
        Task UpdateAsync(string id, Party party);
        Task DeleteAsync(string id);
    }
}
