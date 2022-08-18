using GameMatcherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class UserDAO : IUserDataService
    {
        private readonly IMongoCollection<User> _usersCollection;
        private readonly IMongoCollection<UserGame> _userGamesCollection;

        public UserDAO(
            IOptions<MatcherDatabaseSettings> options)
        {
            string? password = File.ReadAllText(@"M:\Docs\Developer\Utils\password.txt");
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(options.Value.UsersCollectionName);
            _userGamesCollection = mongoDatabase.GetCollection<UserGame>(options.Value.UserGamesCollectionName);
        }
        public async Task<List<User>> GetAsync() =>
           await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetByIdAsync(string id) =>
            await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(User user) =>
            await _usersCollection.InsertOneAsync(user);

        public async Task UpdateAsync(string id, User user) =>
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, user);

        public async Task DeleteAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Id == id);

        public async Task<UserGame> GetUserGamesAsync(User user) =>
            await _userGamesCollection.Find(x => x.User.Id == user.Id).FirstOrDefaultAsync(); // Testing Pending
    }
}
