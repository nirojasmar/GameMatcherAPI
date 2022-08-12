using GameMatcherAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class GameDAO : IGameDataService
    {
        public GameDAO()
        {
            string? password = File.ReadAllText(@"M:\Docs\Developer\Utils\password.txt");
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            List<string> databases = client.ListDatabaseNames().ToList();
        }
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
