using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.Models
{
    public class FileDetails
    {
        [Key]
        public int FileID { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        public virtual void Modify(IFormFile file) { }
    }
}
