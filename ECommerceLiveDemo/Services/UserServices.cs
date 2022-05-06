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
    }
}