using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class User
    {   
        public ObjectId Id { get; set; }

        [BsonElement("username")]
        public string Name { get; set; }
        public int Age { get; set; }
        public Rating? Rating { get; set; }

        public User(string name)
        {
            this.Name = name;
        }
    }
}