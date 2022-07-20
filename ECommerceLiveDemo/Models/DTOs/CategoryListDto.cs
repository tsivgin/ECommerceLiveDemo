using System.Collections.Generic;

namespace ECommerceLiveDemo.Models.DTOs
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryPicture { get; set; }
        public List<Category> ChildCategory { get; set; }
    }
}