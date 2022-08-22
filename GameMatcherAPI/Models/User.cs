using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class User
    {   
        [BsonId]
        [BsonElement("_id")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("ratings")]
        public List<Rating>? Rating { get; set; }

        public User(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}