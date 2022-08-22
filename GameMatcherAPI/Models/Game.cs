using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Game
    {
        [BsonId]
        [BsonElement("_id")]
        public string Name { get; set; }

        [BsonElement("hasRanked")]
        public bool HasRanked { get; set; }

        [BsonElement("maxGroupSize")]
        public int MaxGroupSize { get; set; }

        [BsonElement("gamemodes")]
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
