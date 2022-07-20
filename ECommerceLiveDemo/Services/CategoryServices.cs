using System.Collections.Generic;
using System.Linq;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;

namespace ECommerceLiveDemo.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly SHOPContext _context;

        public CategoryServices(SHOPContext context)
        {
            _context = context;
        }

        public List<CategoryListDto> GetCategory()
        {
            List<CategoryListDto> categoryListDtos = new List<CategoryListDto>();
            var category = _context.Categories.Where(i=>i.ParentId == 0).ToList();
            foreach (var item in category)
            {
                categoryListDtos.Add(new CategoryListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryPicture = item.CategoryPicture,
                    ChildCategory = _context.Categories.Where(i=>i.ParentId== item.Id).ToList()
                });
            }
            return categoryListDtos;
        }

        public Category GetCategoryById(int Id)
        {
            var category = _context.Categories.FirstOrDefault(i => i.Id == Id);
            return category;
        }
    }
}