using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace AMS.Infrastructure.Service.StorageServices
{
    public class StorageService : IStorageService
    {
        private readonly IWebHostEnvironment _environment;

        public StorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveFile(string fileBase64, string folderName, string extension)
        {
            // Throw EmptyFileException 

            if (fileBase64.Length <= 0) throw new NotImplementedException();


            var fileBytes = Convert.FromBase64String(fileBase64);


            var uploadPath = Path.Combine(_environment.WebRootPath, folderName);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Generate New Random File Name

            var fileName = Guid.NewGuid().ToString().Replace("-", "") + extension;

            var filePath = Path.Combine(uploadPath, fileName);

            await File.WriteAllBytesAsync(filePath, fileBytes);


            // We Return FilePath 


            return filePath;
        }

        public async Task<string> GetFile(string filePath)
        {
            // Throw EmptyFilePathException 

            if (filePath.Length <= 0) throw new System.NotImplementedException();

            // First We Get File As Byte Array 

            var fileBytes = await File.ReadAllBytesAsync(filePath);

            // Then Return File As Base64

            return Convert.ToBase64String(fileBytes);
        }
    }
}