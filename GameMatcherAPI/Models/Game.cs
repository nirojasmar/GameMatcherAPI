using System.ComponentModel.DataAnnotations;

namespace GameMatcherAPI.Models
{
    public class Game
    {
        [Key]
        public ulong Id { get; set; }
        public string? Name { get; set; }
        public bool IsFavorite { get; set; }
        public bool HasRanked { get; set; }
        public int MaxGroupSize { get; set; }
        public List<string>? Gamemodes { get; set; }
    }
}
