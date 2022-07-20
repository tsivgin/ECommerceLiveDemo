using System.Collections.Generic;

namespace ECommerceLiveDemo.Models.DTOs
{
    public class UploadVideoDto
    {
        public BrandsDto BrandsDto { get; set; }
        public List<CategoryListDto> Categories { get; set; }
    }
}