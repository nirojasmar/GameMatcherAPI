using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameMatcherAPI.Models
{
    public class Party
    {
        public ObjectId Id { get; set; }
        public List<User>? Users { get; set; }
    }
}
