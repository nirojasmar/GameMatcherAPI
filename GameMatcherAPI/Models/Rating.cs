using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Rating
    {
        [BsonId]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("user_id")]
        public string? User { get; set; }

        [BsonElement("game_id")]
        public string GameId { get; set; }

        [BsonElement("rating_stars")]
        public double Stars { get; set; }

        [BsonElement("rating_text")]
        public string? Comment { get; set; }

        [BsonElement("published_date")]
        public DateTime Date { get; set; }
    }
}
