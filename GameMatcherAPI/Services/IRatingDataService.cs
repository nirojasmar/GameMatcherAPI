using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public interface IRatingDataService
    {
        Task<List<Rating>> GetAsync();
        Task<List<Rating>> GetRatingsByUserAsync(string user_id);
        Task<Rating> GetRatingAsync(string id);
        Task InsertAsync(Rating rating);
        Task UpdateAsync(string id, Rating rating);
        Task DeleteAsync(string id);
    }
}
