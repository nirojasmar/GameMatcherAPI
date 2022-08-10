using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public interface IUserDataService
    {
        List<User> GetUsers();
        User GetUserById(ObjectId id);
        User InsertUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(ObjectId id);
        List<Rating> GetRatings();
        UserGame GetUserGameInfo(ObjectId id);
    }
}
