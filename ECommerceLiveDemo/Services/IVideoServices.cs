using System.Collections.Generic;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;

namespace ECommerceLiveDemo.Services
{
    public interface IVideoServices
    {
        public StremingVideoDto SetStreamingVideoDto();
        public List<Video> GetVideosByCategoryId(int categoryId);
        public List<Video> GetVideosById(int Id);
        List<Video> GetVideosByBrandId(int brandId);
    }
}