using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ECommerceLiveDemo.Services
{
    public class FileService : IFileService
    {
        
        public string InsertImageForBrands(IFormFile file,string brandEmail)
        {
            string imageExtension = Path.GetExtension(file.FileName);
            string imageName = Guid.NewGuid()  + imageExtension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/brands/{imageName}");

            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(512, 512));
            image.Save(path);
            
            // using var stream = new FileStream(path, FileMode.Create);
            // file.CopyTo(stream);
            
            return  path.Substring(path.LastIndexOf("wwwroot")).Replace("wwwroot/", "https://begendinmi.sitesi.tv/");
        }
        public string InsertVideoForBrands(IFormFile file)
        {
            string imageExtension = Path.GetExtension(file.FileName);
            string imageName = Guid.NewGuid()  + imageExtension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/videos/brands/{imageName}");

            using var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            
            return  path.Substring(path.LastIndexOf("wwwroot")).Replace("wwwroot/", "https://begendinmi.sitesi.tv/");
        }
        public string InsertImageForCategory(IFormFile file)
        {
            string imageExtension = Path.GetExtension(file.FileName);
            string imageName = Guid.NewGuid()  + imageExtension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/category/{imageName}");

            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(512, 512));
            image.Save(path);
            
            // using var stream = new FileStream(path, FileMode.Create);
            // file.CopyTo(stream);
            
            return  path.Substring(path.LastIndexOf("wwwroot")).Replace("wwwroot/", "https://begendinmi.sitesi.tv/");
        }
    }
}