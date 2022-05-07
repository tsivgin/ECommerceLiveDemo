using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;
using ECommerceLiveDemo.Services;
using Jil;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

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
        var brandsDto = _brandServices.SetBrandsDto();
        var streamingVideoDto = _videoServices.SetStreamingVideoDto();
        streamingVideoDto.BrandsDto = brandsDto;
        var a = User.Identity.Name;
        var role = User
            .Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
        return View(streamingVideoDto);
    }

    [Route("GetBrands")]
    public IActionResult GetBrands(bool IsBrand)
    {
        var brandsDto = _brandServices.SetBrandsDto();
        if (IsBrand)
        {
            return new OkObjectResult(JsonConvert.SerializeObject( brandsDto.Brands.ToList()));
        }
        else
        { 
            return new OkObjectResult(JsonConvert.SerializeObject(brandsDto.Influencers));
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
   
}
}