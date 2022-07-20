using System.Collections.Generic;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;

namespace ECommerceLiveDemo.Services
{
    public interface ICategoryServices
    {
        List<CategoryListDto> GetCategory();
        public Category GetCategoryById(int Id);
    }
}