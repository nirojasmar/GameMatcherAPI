using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("hasRanked")]
        public bool HasRanked { get; set; }

        [BsonElement("maxGroupSize")]
        public int MaxGroupSize { get; set; }

        [BsonElement("gamemodes")]
        [BsonRepresentation(BsonType.Array)]
        public List<string> Gamemodes { get; set; }

        public Game(string name, bool hasRanked, int maxGroupSize, List<string> gamemodes)
        {
            this.Name = name;
            this.HasRanked = hasRanked;
            this.MaxGroupSize = maxGroupSize;
            this.Gamemodes = gamemodes;
        }
    }
}
