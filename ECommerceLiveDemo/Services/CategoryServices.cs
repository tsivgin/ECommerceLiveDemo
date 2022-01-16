using System.Collections.Generic;
using System.Linq;
using ECommerceLiveDemo.Models;

namespace ECommerceLiveDemo.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly SHOPContext _context;

        public CategoryServices(SHOPContext context)
        {
            _context = context;
        }

        public List<Category> GetCategory()
        {
            var category = _context.Categories.ToList();
            return category;
        }
    }
}