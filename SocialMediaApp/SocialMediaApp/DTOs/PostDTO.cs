namespace SocialMediaApp.DTOs
{
    public class PostDTO
    {
        public string UserID { get; set; }
        public string Content { get; set; }
        public string MediaType { get; set; }
        public string MediaURL { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class UpdatePostDTO
    {
        public string UserID { get; set; }
        public string Content { get; set; }
        public string MediaType { get; set; }
        public string MediaURL { get; set; }
    }
}
