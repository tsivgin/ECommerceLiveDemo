using System.Collections.Generic;

namespace ECommerceLiveDemo.Models.DTOs
{
    public class CategoryDto
    {
        public string? BrandName { get; set; }
        public Category? Category { get; set; }
        public List<Video>? Videos { get; set; }
        public Video? PlayingVideo { get; set; }
        public List<Product>? Products { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}