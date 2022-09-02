using GameMatcherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class UserDAO : IUserDataService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserDAO(
            IOptions<MatcherDatabaseSettings> options)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + options.Value.DatabasePassword + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(options.Value.UsersCollectionName);
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
    }
}
