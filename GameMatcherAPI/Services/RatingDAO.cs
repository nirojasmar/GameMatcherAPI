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
            string? password = File.ReadAllText(@"../password.txt");
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _ratingsCollection = mongoDatabase.GetCollection<Rating>(options.Value.RatingsCollectionName);    
        }

        public async Task<List<Rating>> GetAllRatings() =>
            await _ratingsCollection.Find(_ => true).ToListAsync();
        Rating GetRatingByAuthor(string id);
        Rating InsertRating(Rating rating);
        Rating UpdateRating(Rating rating);
        bool DeleteRating(string id);
    }
}
