using System.Collections.Generic;
using ECommerceLiveDemo.Models;

namespace ECommerceLiveDemo.Services
{
    public interface ICategoryServices
    {
        public List<Category> GetCategory();
    }
}