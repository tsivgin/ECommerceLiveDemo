using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductVideoMappings = new HashSet<ProductVideoMapping>();
        }

        public int Id { get; set; }
        [DisplayName("Ürün İsmi")]
        public string Name { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public double? Price { get; set; }
        [DisplayName("Ürün Eski Fiyatı")]
        public double? OldPrice { get; set; }
        [DisplayName("Marka İsmi")]
        public int? BrandId { get; set; }
        [DisplayName("Ürün Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; }
        [DisplayName("Ürün Güncellenme Tarihi")]
        public DateTime? UpdateDate { get; set; }
        [DisplayName("Marka İsmi")]
        public virtual Brand Brand { get; set; }
        [DisplayName("Resim İsmi")]
        public string FileName { get; set; }
        [DisplayName("Resim Url'i")]
        public string FileUrl { get; set; }
        [DisplayName("Ürün Url'i")]
        public string ProductUrl { get; set; }
        public virtual ICollection<ProductVideoMapping> ProductVideoMappings { get; set; }
    }
}
