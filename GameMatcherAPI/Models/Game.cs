namespace GameMatcherAPI.Models
{
    public class Game
    {
        public ulong Id { get; set; }
        public string? Name { get; set; }
        public bool IsFavorite { get; set; }
    }
}
