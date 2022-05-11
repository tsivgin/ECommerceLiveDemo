using ECommerceLiveDemo.Models;

namespace ECommerceLiveDemo.Services
{
    public interface IUserServices
    {
        User LoginAction(User user);
        User GetUser(string email);
    }
}