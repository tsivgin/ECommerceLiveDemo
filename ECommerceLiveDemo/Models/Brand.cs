using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
            VideoBrandMappings = new HashSet<VideoBrandMapping>();
        }

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

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<BrandUserMapping> BrandUserMappings { get; set; }
        public virtual ICollection<VideoBrandMapping> VideoBrandMappings { get; set; }
    }
}
