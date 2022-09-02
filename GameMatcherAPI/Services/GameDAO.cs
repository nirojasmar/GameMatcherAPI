using GameMatcherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class GameDAO : IGameDataService
    {
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly IMongoCollection<UserGame> _userGamesCollection;

        public GameDAO(
            IOptions<MatcherDatabaseSettings> options)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + options.Value.DatabasePassword + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _gamesCollection = mongoDatabase.GetCollection<Game>(options.Value.GamesCollectionName);
            _userGamesCollection = mongoDatabase.GetCollection<UserGame>(options.Value.UserGamesCollectionName);
        }

        //TODO: Check Functions performance and DB clutter
        public async Task<List<Game>> GetAsync() =>
            await _gamesCollection.Find(_ => true).ToListAsync();
        public async Task<Game> GetGameByIdAsync(string id) =>
            await _gamesCollection.Find(x => x.Name == id).FirstOrDefaultAsync();
        public async Task<List<UserGame>> GetUserGamesAsync(string name) =>
            await _userGamesCollection.Find(x => x.User == name).ToListAsync();
        public async Task InsertAsync(Game game) =>
            await _gamesCollection.InsertOneAsync(game);
        public async Task UpdateAsync(string id, Game game) =>
            await _gamesCollection.ReplaceOneAsync(x => x.Name == id, game);
        public async Task DeleteAsync(string id) =>
            await _gamesCollection.DeleteOneAsync(x => x.Name == id);
    }
}
