using GameMatcherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class RatingDAO: IRatingDataService
    {
        private readonly IMongoCollection<Rating> _ratingsCollection;
        
        public RatingDAO(
            IOptions<MatcherDatabaseSettings> options)
        {
            string? password = File.ReadAllText(@"./password.txt");
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _ratingsCollection = mongoDatabase.GetCollection<Rating>(options.Value.RatingsCollectionName);    
        }
        //TODO: Introduce a way to when creating rating, user collection needs to be updated with the 20 most recent ratings from UserDAO or RatingDAO
        public async Task<List<Rating>> GetAsync() =>
            await _ratingsCollection.Find(_ => true).ToListAsync();
        public async Task<List<Rating>> GetRatingsByUserAsync(string user_id) =>
            await _ratingsCollection.Find(x => x.User == user_id).ToListAsync();
        public async Task<Rating> GetRatingAsync(string id) =>
            await _ratingsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task InsertAsync(Rating rating) =>
            await _ratingsCollection.InsertOneAsync(rating);
        public async Task UpdateAsync(string id, Rating rating) =>
            await _ratingsCollection.ReplaceOneAsync(x => x.Id == id, rating);
        public async Task DeleteAsync(string id) =>
            await _ratingsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
