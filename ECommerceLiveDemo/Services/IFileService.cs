using Microsoft.AspNetCore.Http;

namespace ECommerceLiveDemo.Services
{
    public interface IFileService
    {
        string InsertImageForBrands(IFormFile file, string brandEmail);
        string InsertVideoForBrands(IFormFile file);
        string InsertImageForCategory(IFormFile file);
    }
}