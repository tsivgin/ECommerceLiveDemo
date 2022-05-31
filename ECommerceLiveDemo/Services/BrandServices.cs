using System.Collections.Generic;
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
            var allBrandsDto = new List<BrandDto>();
            foreach (var brand in allBrands)
            {
                allBrandsDto.Add(new BrandDto
                    {
                        Id = brand.Id,
                        ImageLink = brand.ImageLink,
                        Name = brand.Name,
                        IsBrand = brand.IsBrand
                    }
                );
            }

            var influencer = allBrandsDto.Where(i => !i.IsBrand).ToList();
            var brands = allBrandsDto.Where(i => i.IsBrand).ToList();

            return new BrandsDto()
            {
                Influencers = influencer,
                Brands = brands
            };
        }

        public Brand? GetBrandById(int Id)
        {
            return  _context.Brands.FirstOrDefault(i => i.Id == Id);
        }
    }
}