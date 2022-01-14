using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductCategoryMappings = new HashSet<ProductCategoryMapping>();
        }

        public int Id { get; set; }
        [DisplayName("Kategori İsmi")]
        public string Name { get; set; }
        [DisplayName("Kategori Sistem İsmi")]
        public string SystemName { get; set; }
        [DisplayName("Kategori Parent Id'si")]
        public int? ParentId { get; set; }

        public virtual ICollection<ProductCategoryMapping> ProductCategoryMappings { get; set; }
    }
}
