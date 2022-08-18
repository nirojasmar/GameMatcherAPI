using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Rating
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("rating_id")]  // For some reason this doesnt relate to Id
        public long? RatingId { get; set; }

        [BsonElement("rating_stars")]
        public double Stars { get; set; }

        [BsonElement("rating_text")]
        public string? Comment { get; set; }

        [BsonElement("author_id")]
        public string? Author { get; set; } //Check if change to User Type is supported

        [BsonElement("game_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? GameId { get; set; }

        [BsonElement("published_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }

        // Constructor for testing purposes TODO: Include Author into the constructor
        public Rating(double stars)
        {
            Stars = stars;
            Date = DateTime.Now;
        }
    }
}
