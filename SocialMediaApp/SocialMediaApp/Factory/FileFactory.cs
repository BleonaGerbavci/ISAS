using SocialMediaApp.Models;
using System.Net.NetworkInformation;

namespace SocialMediaApp.Factory
{
    public class FileFactory
    {
        // RIP pattern
        private static Dictionary<string, FileDetails> FilesDictionary =
            new Dictionary<string, FileDetails>()
            {
               { "image/png", new Photo() },
                { "image/jpeg", new Photo() },
                { "image/jpg", new Photo() },
                { "video/mp4", new Video() },
                { "video/mpeg", new Video() },
                { "video/ogg", new Video() }
            };
        //factory pattern
        public static FileDetails CreateFileDetails(IFormFile fileData)
        {
            return FilesDictionary[fileData.ContentType];


            /* if (fileData.ContentType.Equals("image/png"))
             {
                 return new Photo()
                 {
                     ID = 0,
                     FileName = fileData.FileName,
                 };
             }
             else if (fileData.ContentType.Equals(""))
             {
                 return new Video()
                 {
                     ID = 1,
                     FileName = fileData.FileName,
                 };
             }
             else
             {
                 throw new Exception("Unsupported file type.");
             }
            */
        }
    }
}
