namespace GameMatcherAPI.Models
{
    public class MatcherDatabaseSettings
    {
        public string? DatabaseName { get; set; }
        public string? UsersCollectionName { get; set; }
        public string? GamesCollectionName { get; set; }
        public string? RatingsCollectionName { get; set; }
        public string? UserGamesCollectionName { get; set; }
        public string? PartiesCollectionName { get; set; }
    }
}
