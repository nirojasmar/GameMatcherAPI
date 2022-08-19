using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Rating
    {
        [BsonId]
        public string? Id { get; set; }

        [BsonElement("author_id")]
        public string Author { get; set; } //Check if change to User Type is supported

        [BsonElement("user_id")]
        public string User { get; set; }

        [BsonElement("game_id")]
        public string GameId { get; set; }

        [BsonElement("rating_stars")]
        public double Stars { get; set; }

        [BsonElement("rating_text")]
        public string? Comment { get; set; }

        [BsonElement("published_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }

        public Rating(double stars, User author, Game game)
        {
            Author = author.Name;
            GameId = game.Name;
            Stars = stars;
            Date = DateTime.Now;
        }
    }
}
