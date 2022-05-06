using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceLiveDemo.Controllers
{
    public class CustomerController : Controller
    { 
        private readonly ILogger<UploadVideoController> _logger;
        private readonly IUserServices _userServices; 
        
        public CustomerController(
            ILogger<UploadVideoController> logger,
            IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }
        
        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string username)
        { 
            
            return View();
        }
        
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var login = _userServices.LoginAction(user);
            if (login !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Email),
                    new Claim(ClaimTypes.Role,"Admin")
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}