using MongoDB.Bson;
using GameMatcherAPI.Models;

namespace GameMatcherAPI.Services
{
    public interface IGameDataService
    {
        Task<List<Game>> GetAsync();
        Task<Game> GetGameById(string id);
        Task<Game> GetGameByName(string name);
        Task InsertGame(Game game);
        Task UpdateGame(string id, Game game);
        Task DeleteGame(string id);
    }
}
