using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ECommerceLiveDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SHOPContext _context;
        private readonly IBrandServices _brandServices;
        private readonly IVideoServices _videoServices;

        public HomeController(ILogger<HomeController> logger,
            SHOPContext context,
            IBrandServices brandServices,
            IVideoServices videoServices)
        {
            _logger = logger;
            _context = context;
            _brandServices = brandServices;
            _videoServices = videoServices;
        }

        public IActionResult Index()
        {
            // var brandsDto = _brandServices.SetBrandsDto();
            var streamingVideoDto = _videoServices.SetStreamingVideoDto();
            streamingVideoDto.Brands = _brandServices.GetPopularBrands();
            
            return View(streamingVideoDto);
        }

        [Route("GetBrands")]
        public IActionResult GetBrands(bool IsBrand)
        {
            
            
            var brandsDto = _brandServices.SetBrandsDto();
            if (IsBrand)
            {
                return new OkObjectResult(JsonConvert.SerializeObject(brandsDto.Brands));
            }

            return new OkObjectResult(JsonConvert.SerializeObject(brandsDto.Influencers));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}