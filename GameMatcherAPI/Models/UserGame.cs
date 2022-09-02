using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class UserGame
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        public string User { get; set; }

        [BsonElement("game_id")]
        public string? Game { get; set; }

        [BsonElement("username")]
        public string Username { get; set; } //Game username (different to app username)

        [BsonElement("range")]
        public string? Range { get; set; }

        [BsonElement("level")]
        public int? Level { get; set; }

        [BsonElement("region")]
        public string? Region { get; set; }

        [BsonElement("role")]
        public string? Role { get; set; }

        public UserGame(string user, string game, string username)
        {
            this.User = user;
            this.Game = game;
            this.Username = username;
        }
    }
}
