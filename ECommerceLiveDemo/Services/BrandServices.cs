using System.Linq;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;

namespace ECommerceLiveDemo.Services
{
    public class BrandServices : IBrandServices
    {
        private readonly SHOPContext _context;

        public BrandServices(SHOPContext context)
        {
            _context = context;
        }
        public BrandsDto SetBrandsDto()
        {
            var allBrands = _context.Brands.ToList();
            var influencer = allBrands.Where(i=>!i.IsBrand).ToList();
            var brands = allBrands.Where(i => i.IsBrand).ToList();
            return new BrandsDto()
            {
                Influencers = influencer,
                Brands = brands
            };
        }
    }
}