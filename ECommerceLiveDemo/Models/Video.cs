using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class Video
    {
        public Video()
        {
            VideoCategoryMappings = new HashSet<VideoCategoryMapping>();
            ProductVideoMappings = new HashSet<ProductVideoMapping>();
            VideoBrandMappings = new HashSet<VideoBrandMapping>();
        }

        public int Id { get; set; }
        [DisplayName("Dosya İsmi")]
        public string FileName { get; set; }
        [DisplayName("Video Url'i")]
        public string FileUrl { get; set; }
        [DisplayName("İsim")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Görünen İlk Resim")]
        public string FirstImageLink { get; set; }
        [DisplayName("Görünen İkinci Resim")]
        public string SecondImageLink { get; set; }
        [DisplayName("Oluşturulma Tarihi")]
        public DateTime? CreatedDate { get; set; }
        public bool IsYoutubeLink { get; set; }
        public virtual ICollection<VideoCategoryMapping> VideoCategoryMappings { get; set; }
        public virtual ICollection<ProductVideoMapping> ProductVideoMappings { get; set; }
        public virtual ICollection<VideoBrandMapping> VideoBrandMappings { get; set; }
    }
}
