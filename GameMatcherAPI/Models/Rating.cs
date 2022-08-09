using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Rating
    {
        public ObjectId Id { get; set; }
        public double Stars { get; set; }
        public string? Comment { get; set; }

        [BsonElement("user")]
        public User? Author { get; set; }
        public DateTime Date { get; set; }

        // Constructor for testing purposes TODO: Include Author into the constructor
        public Rating(double stars)
        {
            Stars = stars;
            Date = DateTime.Now;
        }
    }
}
