using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.Models
{
    public class Like
    {
        public int LikeID { get; set; }

        [ForeignKey("Post")]
        public int? PostID { get; set; }
        public Post Post { get; set; }

        [ForeignKey("Comment")]
        public int? CommentID { get; set; }
        public Comment Comment { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public User User { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
