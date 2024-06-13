using SocialMediaApp.Models;

namespace SocialMediaApp.Interfaces
{
    public interface IFile
    {
        public Task<FileDetails> PostFileAsync(IFormFile fileData);

        public Task DownloadFileById(int fileName);

        public FileDetails GetFileById(int fileId);

        public List<FileDetails> GetAll();
    }
}
