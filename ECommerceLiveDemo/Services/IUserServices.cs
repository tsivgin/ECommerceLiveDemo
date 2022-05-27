using System.Threading.Tasks;
using ECommerceLiveDemo.Models;

namespace ECommerceLiveDemo.Services
{
    public interface IUserServices
    {
        User LoginAction(User user);
        User GetUser(string email);
        Task RegisterAction(User user);
        Task RegisterCustomerRole(string Email,string Role);
    }
}