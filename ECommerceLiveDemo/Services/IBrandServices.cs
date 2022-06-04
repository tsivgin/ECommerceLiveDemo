using System.Collections.Generic;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;

namespace ECommerceLiveDemo.Services
{
    public interface IBrandServices
    {
        public BrandsDto SetBrandsDto();
        Brand? GetBrandById(int Id);
        List<Brand> GetPopularBrands();
    }
}