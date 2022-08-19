using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class UserGame
    {
        public ObjectId Id { get; set; }
        public User User { get; set; }
        public Game? Game { get; set; }
        public string Username { get; set; } //Game username (different to app username)
        public string? Range { get; set; }
        public int? Level { get; set; }
        public string? Region { get; set; }
        public string? Role { get; set; }

        public UserGame(User user, Game game, string username)
        {
            this.User = user;
            this.Game = game;
            this.Username = username;
        }
    }
}
