namespace SocialMediaApp.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; } = null!;
        public string? Bio { get; set; } = null!;
        public string? ProfilePicture { get; set; } = null!;
    }

    public class UpdateUserDTO
    {
        public string? Name { get; set; } 
        public string? Email { get; set; }
        public string Username { get; set; } = null!;
        public string? Bio { get; set; } = null!;
        public string? ProfilePicture { get; set; } = null!;
    }
}
