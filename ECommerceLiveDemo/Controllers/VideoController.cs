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
            var brandsDto = _brandServices.SetBrandsDto();
            var videos = _videoServices.GetVideosById(Id);
            var playingVideo = videos.LastOrDefault();
            var category =
                _categoryServices.GetCategoryById(playingVideo.VideoCategoryMappings.FirstOrDefault().CategoryId.Value);
            var CategoryDto = new CategoryDto()
            {
                BrandsDto = brandsDto,
                Category = category,
                Videos = videos,
                PlayingVideo = playingVideo,
                Products = playingVideo?.ProductVideoMappings.Select(i => i.Product).ToList()
            };
            return View(CategoryDto);
        }
    }
}