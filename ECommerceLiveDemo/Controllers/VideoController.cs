using System.Linq;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceLiveDemo.Controllers
{
    public class VideoController: Controller
    { 
        private readonly ILogger<UploadVideoController> _logger;
        private readonly SHOPContext _context;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IVideoServices _videoServices;

        public VideoController(
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
        
        
        [Route("Video/{id?}")]
        public IActionResult List(int Id)
        { 
            var playingVideo = _videoServices.GetVideosById(Id).LastOrDefault();
            var category =
                _categoryServices.GetCategoryById(playingVideo.VideoCategoryMappings.FirstOrDefault().CategoryId.Value);
            var videos = _videoServices.GetVideosByCategoryId(category.Id);
            var popularBrands = _brandServices.GetPopularBrands();
            var CategoryDto = new CategoryDto()
            {
                Category = category,
                Videos = videos,
                PlayingVideo = playingVideo,
                Products = playingVideo?.ProductVideoMappings.Select(i => i.Product).ToList(),
                Brands = popularBrands
            };
            return View(CategoryDto);
        }
        
        [Route("Brands/{id?}")]
        public IActionResult BrandsList(int Id)
        {
            var brand = _brandServices.GetBrandById(Id);
            var videos = _videoServices.GetVideosByBrandId(Id);
            var playingVideo = videos.LastOrDefault();
            var popularBrands = _brandServices.GetPopularBrands();
            if (playingVideo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var CategoryDto = new CategoryDto()
            {
                BrandName = brand.Name,
                Videos = videos,
                PlayingVideo = playingVideo,
                Products = playingVideo?.ProductVideoMappings.Select(i => i.Product).ToList(),
                Brands = popularBrands
            };
           
            return View(CategoryDto);
        }
    }
}