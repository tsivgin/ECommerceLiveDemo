using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceLiveDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceLiveDemo.Services
{
    public class UserServices : IUserServices
    {
        private readonly SHOPContext _context;

        public UserServices(SHOPContext context)
        {
            _context = context;
        }
        public  User LoginAction(User user)
        {
            var login = _context.Users.FirstOrDefault(i=>i.Email == user.Email && i.Password == user.Password);
            return login;
        }
        public  User GetUser(string email)
        {
            var user = _context.Users.FirstOrDefault(i=>i.Email == email);
            return user;
        }
        public  List<string> GetUserRolesByUser(User user)
        {
            var userRoles = _context.Users.FirstOrDefault(i=>i.Id == user.Id).UserUserRoleMappings.Select(i=>i.UserRole);
            var userRoleNames = userRoles.Select(i => i.Name).ToList();
            return userRoleNames;
        }
        public async  Task RegisterAction(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task RegisterCustomerRole(string Email, string Role)
        {
            var getUser = GetUser(Email);
            UserUserRoleMapping userRoleMapping = new UserUserRoleMapping
            {
                User = getUser,
                UserId = getUser.Id,
                UserRoleId = _context.UserRoles.FirstOrDefault(i=>i.Name == Role)?.Id
            };
            _context.UserUserRoleMappings.Add(userRoleMapping);
            await _context.SaveChangesAsync();
        }
    }
}