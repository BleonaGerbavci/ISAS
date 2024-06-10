using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.Models
{
    public class Post
    {
        public int PostID { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public string MediaType { get; set; }
        public string MediaURL { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
