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
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IVideoServices _videoServices;

        public CategoryController(
            IBrandServices brandServices,
            ICategoryServices categoryServices,
            IVideoServices videoServices)
        {
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
            var category = _categoryServices.GetCategoryById(Id);
            var videos = _videoServices.GetVideosByCategoryId(Id);
            var playingVideo = videos.LastOrDefault();
            var brands = _brandServices.GetPopularBrands();
            if (playingVideo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var CategoryDto = new CategoryDto()
            {
                Category = category,
                Videos = videos,
                PlayingVideo = playingVideo,
                Products = playingVideo?.ProductVideoMappings.Select(i => i.Product).ToList(),
                Brands = brands
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