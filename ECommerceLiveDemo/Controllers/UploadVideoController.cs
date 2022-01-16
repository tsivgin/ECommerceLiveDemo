using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceLiveDemo.Controllers
{
    public class UploadVideoController : Controller
    {
        private readonly ILogger<UploadVideoController> _logger;
        private readonly SHOPContext _context;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;

        public UploadVideoController(
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
        
        public IActionResult Index()
        {
            var brandsDto = _brandServices.SetBrandsDto();
            var categories = _categoryServices.GetCategory();
            var uploadVideoDto = new UploadVideoDto()
            {
                BrandsDto = brandsDto,
                Categories = categories
            };
            return View(uploadVideoDto);
        }
    }
}