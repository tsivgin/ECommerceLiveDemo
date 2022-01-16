using System.Diagnostics;
using System.Linq;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerceLiveDemo.Controllers
{
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SHOPContext _context;
    private readonly IBrandServices _brandServices;
    public HomeController(ILogger<HomeController> logger,SHOPContext context,IBrandServices brandServices)
    {
        _logger = logger;
        _context = context;
        _brandServices = brandServices;
    }

    public IActionResult Index()
    {
        var brandsDto = _brandServices.SetBrandsDto();
        return View(brandsDto);
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