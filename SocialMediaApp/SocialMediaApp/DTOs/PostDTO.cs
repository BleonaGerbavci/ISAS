using Microsoft.AspNetCore.Mvc.Formatters;
using SocialMediaApp.Models;

namespace SocialMediaApp.DTOs
{
    public class PostDTO
    {
        public string UserID { get; set; }
        public string Content { get; set; }
        public string MediaType { get; set; }
        public string MediaURL { get; set; }
        public DateTime Timestamp { get; set; }
    

    public PostDTO(string userId, string content, string mediaType, string mediaUrl, DateTime timestamp)
    {
        UserID = userId;
        Content = content;
        MediaType = mediaType;
        MediaURL = mediaUrl;
        Timestamp = timestamp;
    }
}

    public class UpdatePostDTO
    {
        public string UserID { get; set; }
        public string Content { get; set; }
        public string MediaType { get; set; }
        public string MediaURL { get; set; }
    }
}
