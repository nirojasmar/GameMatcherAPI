using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Rating
    {
        [BsonElement("rating_id")]
        public ObjectId Id { get; set; }

        [BsonElement("rating_stars")]
        public double Stars { get; set; }

        [BsonElement("rating_text")]
        public string? Comment { get; set; }
        public User? Author { get; set; }

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
