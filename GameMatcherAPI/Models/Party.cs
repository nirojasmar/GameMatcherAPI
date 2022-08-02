using System.ComponentModel.DataAnnotations;

namespace GameMatcherAPI.Models
{
    public class Party
    {
        [Key]
        public int Id { get; set; }
        public List<User> Users { get; set; }
    }
}
