using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class User
    {   
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string Name { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("ratings")]
        public List<Rating>? Rating { get; set; }

        public User(string name)
        {
            this.Name = name;
        }
    }
}