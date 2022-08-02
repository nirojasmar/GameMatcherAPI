using System.ComponentModel.DataAnnotations;

namespace GameMatcherAPI.Models
{
    public class User
    {   
        [Key]
        public ulong Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Rating? Rating { get; set; }
    }
}