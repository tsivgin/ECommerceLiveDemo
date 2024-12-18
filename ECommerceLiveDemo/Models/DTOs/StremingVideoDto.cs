using System.Collections.Generic;

namespace ECommerceLiveDemo.Models.DTOs
{
    public class StremingVideoDto
    {
        public string VideoUrl { get; set; }
        public string VideoName { get; set; }
        public int Viewer { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public string VideoDescription { get; set; }
        public BrandsDto BrandsDto { get; set; }
    }
}