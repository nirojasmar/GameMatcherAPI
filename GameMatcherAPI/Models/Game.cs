using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Game
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool HasRanked { get; set; }
        public int MaxGroupSize { get; set; }
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
