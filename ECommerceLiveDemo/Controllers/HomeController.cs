using System.Diagnostics;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        return View(streamingVideoDto);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
}