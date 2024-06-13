namespace SocialMediaApp.Models
{
    public class Video: FileDetails
    {
        private int? Duration {  get; set; }
        public override void Modify(IFormFile file)
        {
            FileID = 0;
            FileName = file.FileName;

        }
    }
}
