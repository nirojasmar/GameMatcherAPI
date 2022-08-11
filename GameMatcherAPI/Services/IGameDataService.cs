using MongoDB.Bson;
using GameMatcherAPI.Models;

namespace GameMatcherAPI.Services
{
    public interface IGameDataService
    {
        List<Game> GetGames();
        Game GetGameById(ObjectId id);
        Game GetGameByName(string name);
        Game InsertGame(Game game);
        Game UpdateGame(Game game);
        bool DeleteGame(ObjectId id);
    }
}
