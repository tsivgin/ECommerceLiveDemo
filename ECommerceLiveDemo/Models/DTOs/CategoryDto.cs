using System.Collections.Generic;

namespace ECommerceLiveDemo.Models.DTOs
{
    public class CategoryDto
    {
        public Category Category { get; set; }
        public List<Video> Videos { get; set; }
        public Video PlayingVideo { get; set; }
        public List<Product> Products { get; set; }
    }
}