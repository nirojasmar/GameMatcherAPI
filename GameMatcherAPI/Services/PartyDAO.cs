using GameMatcherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class PartyDAO : IPartyDataService
    {
        private readonly IMongoCollection<Party> _partyCollection;

        public PartyDAO(IOptions<MatcherDatabaseSettings> options)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + options.Value.DatabasePassword + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var mongoDatabase = client.GetDatabase(options.Value.DatabaseName);
            _partyCollection = mongoDatabase.GetCollection<Party>(options.Value.PartiesCollectionName);
        }
        public async Task<List<Party>> GetListAsync() =>
            await _partyCollection.Find(_ => true).ToListAsync();

        public async Task<List<Party>> GetListByGameAsync(string game) =>
            await _partyCollection.Find(x => x.Game == game).ToListAsync();

        public async Task<Party> GetByPlayerAsync(string user) =>
            await _partyCollection.Find(x => x.Users.Exists(y => y.User == user)).FirstOrDefaultAsync();

        public async Task<Party> GetAsync(string id) =>
            await _partyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(Party p) => 
            await _partyCollection.InsertOneAsync(p);

        public async Task UpdateAsync(string id, Party p) =>
            await _partyCollection.ReplaceOneAsync(x => x.Id == id, p);

        public async Task DeleteAsync(string id) =>
            await _partyCollection.DeleteOneAsync(x => x.Id == id);
    }
}
