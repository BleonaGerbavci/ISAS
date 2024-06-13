namespace SocialMediaApp.DTOs
{
    public class LikeDTO
    {
        public int? PostID { get; set; }
        public int? CommentID { get; set; }
        public string UserID { get; set; }
        public DateTime Timestamp { get; set; }
    }
    public class UpdateLikeDTO
    {
        public int? PostID { get; set; }
        public int? CommentID { get; set; }
        public string UserID { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
