using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Party
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        // **** Testing Pending: Change List<User> to List<UserGame> //
        [BsonElement("game")]
        public Game? Game { get; set; } 

        [BsonElement("users")]
        public List<User>? Users { get; set; }

        public Party(User user, Game game)
        {
            Game = game;
            Users = new List<User>();
            Users.Add(user);
        }
    }
}
