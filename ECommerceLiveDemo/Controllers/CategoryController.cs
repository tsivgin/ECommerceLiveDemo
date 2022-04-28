using System.Linq;
using System.Threading.Tasks;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceLiveDemo.Controllers
{
    public class CategoryController: Controller
    { 
        private readonly ILogger<UploadVideoController> _logger;
        private readonly SHOPContext _context;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IVideoServices _videoServices;

        public CategoryController(
            ILogger<UploadVideoController> logger,
            SHOPContext context,
            IBrandServices brandServices,
            ICategoryServices categoryServices,
            IVideoServices videoServices)
        {
            _logger = logger;
            _context = context;
            _brandServices = brandServices;
            _categoryServices = categoryServices;
            _videoServices = videoServices;
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

        [Route("CategoryList/{id?}")]
        public IActionResult List(int Id)
        { 
            var brandsDto = _brandServices.SetBrandsDto();
            var category = _categoryServices.GetCategoryById(Id);
            var videos = _videoServices.GetVideos(Id);
            var playingVideo = videos.LastOrDefault();
            var CategoryDto = new CategoryDto()
            {
                BrandsDto = brandsDto,
                Category = category,
                Videos = videos,
                PlayingVideo = playingVideo,
                Products = playingVideo.ProductVideoMappings.Select(i => i.Product).ToList()
            };
            return View(CategoryDto);
        }
        [Route("Stream")]
        public IActionResult Stream()
        {
            return View();
        }

        [Route("Watching")]
        public IActionResult Watching()
        {
            return View();
        }
        
    }
}