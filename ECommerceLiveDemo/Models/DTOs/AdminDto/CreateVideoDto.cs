using System;
using System.ComponentModel;

namespace ECommerceLiveDemo.Models.DTOs.AdminDto
{
    public class CreateVideoDto
    {
        public int Id { get; set; }
        [DisplayName("Dosya İsmi")] 
        public string? FileName { get; set; }
        [DisplayName("Video Url'i")]
        public string? FileUrl { get; set; }
        [DisplayName("İsim")] 
        public string? Name { get; set; }
        [DisplayName("Açıklama")] 
        public string? Description { get; set; }
        [DisplayName("Görünen İlk Resim")] 
        public string? FirstImageLink { get; set; }
        [DisplayName("Görünen İkinci Resim")] 
        public string? SecondImageLink { get; set; }
        [DisplayName("Oluşturulma Tarihi")] 
        public DateTime? CreatedDate { get; set; }
        [DisplayName("Kategori Id")] 
        public string? CategoryId { get; set; }
        [DisplayName("Brand Id")] 
        public string? BrandId { get; set; }
    }
}