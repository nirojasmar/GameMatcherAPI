﻿using GameMatcherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class RatingDAO: IRatingDataService
    {
        private readonly IMongoCollection<User> _usersCollection;
        private readonly IMongoCollection<Rating> _ratingsCollection;
        
        public RatingDAO(
            IOptions<MatcherDatabaseSettings> options)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + options.Value.DatabasePassword + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(options.Value.UsersCollectionName);
            _ratingsCollection = mongoDatabase.GetCollection<Rating>(options.Value.RatingsCollectionName);    
        }
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
