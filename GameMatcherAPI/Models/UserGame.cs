using System.ComponentModel.DataAnnotations;

namespace GameMatcherAPI.Models
{
    public class UserGame
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public string? Range { get; set; }
        public int Level { get; set; }
        public string? Region { get; set; }
        public string? Role { get; set; }
        public string Username { get; set; }

    }
}
