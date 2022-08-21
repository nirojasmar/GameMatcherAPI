using GameMatcherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class GameDAO : IGameDataService
    {
        private readonly IMongoCollection<Game> _gamesCollection;

        public GameDAO(
            IOptions<MatcherDatabaseSettings> options)
        {
            string? password = File.ReadAllText(@"../password.txt");
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _gamesCollection = mongoDatabase.GetCollection<Game>(options.Value.GamesCollectionName);
        }

        // TODO: Update Functions to reduce clutter
        public async Task<List<Game>> GetAsync() =>
            await _gamesCollection.Find(_ => true).ToListAsync();
        public async Task<Game> GetGameById(string id) =>
            await _gamesCollection.Find(x => x.Name == id).FirstOrDefaultAsync();
        public async Task<Game> GetGameByName(string name) =>
            await _gamesCollection.Find(x => x.Name == name).FirstOrDefaultAsync();
        public async Task InsertGame(Game game) =>
            await _gamesCollection.InsertOneAsync(game);
        public async Task UpdateGame(string id, Game game) =>
            await _gamesCollection.ReplaceOneAsync(x => x.Name == id, game);
        public async Task DeleteGame(string id) =>
            await _gamesCollection.DeleteOneAsync(x => x.Name == id);
    }
}
