using System.Collections.Generic;
using System.Linq;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;

namespace ECommerceLiveDemo.Services
{
    public class VideoServices : IVideoServices
    {
        private readonly SHOPContext _context;

        public VideoServices(SHOPContext context)
        {
            _context = context;
        }

        public StremingVideoDto SetStreamingVideoDto()
        {
            //Buraya bir alan eklenip ona göre çekilmesi gerek Geçici burası
            var videos = _context.Videos.FirstOrDefault();
            var streamingVideoDto = new StremingVideoDto
            {
                VideoUrl = videos.FileUrl,
                VideoName = videos.Name,
                VideoDescription = videos.Description,
                Viewer = 100,
                Products = videos.ProductVideoMappings.Select(i => i.Product).ToList(),
                Categories = _context.Categories.ToList(),
                Videos = _context.Videos.Take(10).ToList()
            };
            return streamingVideoDto;
        }
        
        public List<Video> GetVideosByCategoryId(int categoryId)
        {
            //Buraya bir alan eklenip ona göre çekilmesi gerek Geçici burası
            var videos = _context.Videos.Where(i => i.VideoCategoryMappings.Any(j => j.CategoryId == categoryId)).ToList();
            return videos;
        }
        public List<Video> GetVideosById(int Id)
        {
            var videos = _context.Videos.Where(i => i.Id == Id).ToList();
            return videos;
        }
    }
}