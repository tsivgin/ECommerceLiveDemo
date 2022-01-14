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
            ProductCategoryMappings = new HashSet<ProductCategoryMapping>();
            ProductPictureMappings = new HashSet<ProductPictureMapping>();
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
        public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public virtual ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }
        public virtual ICollection<ProductVideoMapping> ProductVideoMappings { get; set; }
    }
}
