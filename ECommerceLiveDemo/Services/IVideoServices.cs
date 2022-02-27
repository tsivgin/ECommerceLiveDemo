using System.Collections.Generic;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs;

namespace ECommerceLiveDemo.Services
{
    public interface IVideoServices
    {
        public StremingVideoDto SetStreamingVideoDto();
        public List<Video> GetVideos(int categoryId);
    }
}