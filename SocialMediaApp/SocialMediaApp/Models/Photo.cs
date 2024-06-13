namespace SocialMediaApp.Models
{
    public class Photo : FileDetails
    {
        private int? Resolution { get; set; }
        public override void Modify(IFormFile file)
        {
            FileID = 0;
            FileName = file.FileName;

        }
    }
}
