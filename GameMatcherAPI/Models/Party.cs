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

        [BsonElement("game_id")]
        public string Game { get; set; } 

        [BsonElement("users")]
        public List<UserGame>? Users { get; set; }
    }
}
