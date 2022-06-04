using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var login = _userServices.LoginAction(user);
            if (login != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Email),
                    
               };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                foreach (var role in _userServices.GetUserRolesByUser(login))
                {
                    userIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var RegUser = _userServices.GetUser(user.Email);
                if (RegUser == null)
                {
                    await _userServices.RegisterAction(user);
                 
                    await _userServices.RegisterCustomerRole(user.Email,"Customer");
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, "Customer")
                    };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Login", "Customer");
        }

        [Route("GetUser")]
        public IActionResult GetUser()
        {
            User user = new User();
            UserDto userDto = new UserDto();
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                user = _userServices.GetUser(email);
                userDto.IsLogin = true;
                userDto.Name = user.FirstName;
                userDto.IsBrand =
                    user.UserUserRoleMappings.Any(i => i.UserRole.Name == "Influencer" 
                                                       || i.UserRole.Name == "Brand");
            }

            return new OkObjectResult(JsonConvert.SerializeObject(userDto));
        }
        
       
    }
}