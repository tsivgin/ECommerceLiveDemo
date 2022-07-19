using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECommerceLiveDemo.Services
{
    public class FileService : IFileService
    {
        
        public string InsertImageForBrands(IFormFile file,string brandEmail)
        {
            string imageExtension = Path.GetExtension(file.FileName);

            string imageName = Guid.NewGuid()  + imageExtension;

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/brands/{imageName}");

            using var stream = new FileStream(path, FileMode.Create);
            stream.ReadByte();
            file.CopyTo(stream);
            
            return path;
        }
    }
}