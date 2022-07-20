namespace GameMatcherAPI.Models
{
    public class Rating
    {
        public ulong Id { get; set; }
        public double Stars { get; set; }
        public string? Comment { get; set; }
        public User? Author { get; set; }
        public DateTime? Date { get; set; }

        public Rating(ulong id, double stars)
        {
            Id = id;
            Stars = stars;
            Date = DateTime.Now;
        }
    }
}
