using System.ComponentModel.DataAnnotations;

namespace GameMatcherAPI.Models
{
    public class Rating
    {
        [Key]
        public ulong Id { get; set; }
        public double Stars { get; set; }
        public string? Comment { get; set; }
        public User? Author { get; set; }
        public DateTime? Date { get; set; }

        // Constructor for testing purposes
        public Rating(ulong id, double stars)
        {
            Id = id;
            Stars = stars;
            Date = DateTime.Now;
        }
    }
}
