using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public interface IUserDataService
    {
        Task<List<User>> GetAsync();
        Task<User?> GetByIdAsync(string id);
        Task InsertAsync(User user);
        Task UpdateAsync(string id, User user);
        Task DeleteAsync(string id);
    }
}
