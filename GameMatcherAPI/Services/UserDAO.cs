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
            string? password = File.ReadAllText(@"./password.txt");
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(options.Value.UsersCollectionName);
            _userGamesCollection = mongoDatabase.GetCollection<UserGame>(options.Value.UserGamesCollectionName);
        }
        //TODO: When displaying ratings, User model will only have the 20 most recent ratings
        public async Task<List<User>> GetAsync() =>
           await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetByIdAsync(string name) =>
            await _usersCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

        public async Task InsertAsync(User user) =>
            await _usersCollection.InsertOneAsync(user);

        public async Task UpdateAsync(string name, User user) =>
            await _usersCollection.ReplaceOneAsync(x => x.Name == name, user);

        public async Task DeleteAsync(string name) =>
            await _usersCollection.DeleteOneAsync(x => x.Name == name);

        public async Task<UserGame> GetUserGamesAsync(User user) =>
            await _userGamesCollection.Find(x => x.User.Name == user.Name).FirstOrDefaultAsync(); // Testing Pending
    }
}
