namespace ECommerceLiveDemo.Models
{
    public class VideoBrandMapping
    {
        public int Id { get; set; }
        public int? VideoId { get; set; }
        public int? BrandId { get; set; }

        public virtual Video Video { get; set; }
        public virtual Brand Brand { get; set; }
    }
}