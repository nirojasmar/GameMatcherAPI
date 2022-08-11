using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public class UserDAO : IUserDataService
    {
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
