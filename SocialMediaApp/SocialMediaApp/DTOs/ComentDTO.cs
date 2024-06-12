namespace SocialMediaApp.DTOs
{
    public class CommentDTO
    {

        public string UserID { get; set; }

        public int PostID { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
