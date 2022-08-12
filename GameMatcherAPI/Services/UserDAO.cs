using GameMatcherAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameMatcherAPI.Services
{
    public class UserDAO : IUserDataService
    {
        public UserDAO()
        {
            string? password = File.ReadAllText(@"M:\Docs\Developer\Utils\password.txt");
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            List<string> databases = client.ListDatabaseNames().ToList();
        }
        public bool DeleteUser(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public UserGame GetUserGameInfo(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
