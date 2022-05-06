using System.Collections.Generic;
using System.ComponentModel;

namespace ECommerceLiveDemo.Models.DTOs
{
    public class BrandsDto
    {
        public List<BrandDto> Influencers { get; set; }
        
        public List<BrandDto> Brands { get; set; }
    }

    public class BrandDto
    {
        public int Id { get; set; }
        [DisplayName("Marka İsmi")]
        public string Name { get; set; }
        [DisplayName("Marka Url'i")]
        public string SiteUrl { get; set; }
        [DisplayName("Marka Telefon Numarası")]
        public string ContactPhone { get; set; }
        [DisplayName("Marka Emaili")]
        public string ContactEmail { get; set; }
        [DisplayName("Marka Mı? Değil Influencer")]
        public bool IsBrand { get; set; }
        [DisplayName("Resim")]
        public string ImageLink { get; set; }
    }
}