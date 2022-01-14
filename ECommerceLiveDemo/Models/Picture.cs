using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class Picture
    {
        public Picture()
        {
            ProductPictureMappings = new HashSet<ProductPictureMapping>();
        }

        public int Id { get; set; }
        [DisplayName("Resim İsmi")]
        public string FileName { get; set; }
        [DisplayName("Resim Url'i")]
        public string FileUrl { get; set; }

        public virtual ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }
    }
}
