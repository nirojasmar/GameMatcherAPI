using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public class GameDAO : IGameDataService
    {
        public bool DeleteGame(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Game GetGameById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Game GetGameByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public Game InsertGame(Game game)
        {
            throw new NotImplementedException();
        }

        public Game UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
