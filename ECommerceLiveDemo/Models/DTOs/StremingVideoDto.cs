using System.Collections.Generic;

namespace ECommerceLiveDemo.Models.DTOs
{
    public class StremingVideoDto
    {
        public string VideoUrl { get; set; }
        public string VideoImage { get; set; }
        public string VideoName { get; set; }
        public int Viewer { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public string VideoDescription { get; set; }
        public List<Video> Videos { get; set; }
        
        public List<Brand> Brands { get; set; }
    }
}