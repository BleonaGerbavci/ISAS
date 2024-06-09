using Microsoft.AspNetCore.Identity;

namespace SocialMediaApp.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Bio {  get; set; }
        public string ProfilePicture { get; set; }
    }
}
