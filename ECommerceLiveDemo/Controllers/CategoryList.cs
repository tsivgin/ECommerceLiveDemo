using Microsoft.AspNetCore.Mvc;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceLiveDemo.Controllers
{
    public class CategoryList: Controller
    { 
        private readonly ILogger<UploadVideoController> _logger;
        private readonly SHOPContext _context;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;

        public CategoryList(
            ILogger<UploadVideoController> logger,
            SHOPContext context,
            IBrandServices brandServices,
            ICategoryServices categoryServices)
        {
            _logger = logger;
            _context = context;
            _brandServices = brandServices;
            _categoryServices = categoryServices;
        }
        public IActionResult Index(int Id)
        {
             var brandsDto = _brandServices.SetBrandsDto();
             var category = _categoryServices.GetCategoryById(Id);
             var CategoryDto = new CategoryDto()
             {
                 BrandsDto = brandsDto,
                  Category = category
              };
              return View(CategoryDto);
        }
    }
}