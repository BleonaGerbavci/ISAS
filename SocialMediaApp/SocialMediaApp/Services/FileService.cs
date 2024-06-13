using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data;
using SocialMediaApp.Factory;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;
using System;

namespace SocialMediaApp.Services
{
    public class FileService : IFile
    {
        private readonly DataContext _context;

        public FileService(DataContext context)
        {
            _context = context;
        }

        public async Task<FileDetails> PostFileAsync(IFormFile fileData)
        {
            try
            {
                //Factory pattern usage

                FileDetails fileDetails = FileFactory.CreateFileDetails(fileData);

                fileDetails.Modify(fileData);

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                var result = _context.FileDetails.Add(fileDetails);
                await _context.SaveChangesAsync();
                return fileDetails;
            }
            catch (Exception)
            {
                throw;
            }

        }



        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = await _context.FileDetails.FirstOrDefaultAsync(x => x.FileID == Id);

                if (file != null)
                {
                    var content = new MemoryStream(file.FileData);
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "FileDownloaded",
                        file.FileName);

                    await CopyStream(content, path);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public FileDetails GetFileById(int fileId)
        {
            return _context.FileDetails.FirstOrDefault(s => s.FileID == fileId);
        }

        public List<FileDetails> GetAll()
        {
            return _context.FileDetails.ToList();
      
        }
    }

}
