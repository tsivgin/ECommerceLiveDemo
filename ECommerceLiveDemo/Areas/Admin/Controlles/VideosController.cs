using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs.AdminDto;
using ECommerceLiveDemo.Services;
using Microsoft.AspNetCore.Http;


namespace ECommerceLiveDemo.Areas.Admin.Controlles
{
    [Area("Admin")]
    public class VideosController : Controller
    {
        private readonly SHOPContext _context;
        private readonly IFileService _fileService;

        public VideosController(SHOPContext context,
            IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var sHOPContext = _context.Videos;
            return View(await sHOPContext.ToListAsync());
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            //    ViewBag.BrandId = new SelectList(_context.Brands, "Id", "Name");
            // ViewData["BrandName"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryName"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["BrandName"] = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }


        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,FileName,FileUrl,FirstImageLink,SecondImageLink,Description,CategoryId,BrandId")]
            CreateVideoDto videoDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    var path = _fileService.InsertVideoForBrands(file);
                    videoDto.FileUrl = path;
                }
                Video video = new Video
                {
                    CreatedDate = DateTime.UtcNow,
                    Description = videoDto.Description,
                    FileName = videoDto.FileName,
                    Name = videoDto.Name,
                    FileUrl = videoDto.FileUrl,
                    FirstImageLink = videoDto.FirstImageLink,
                };
                _context.Add(video);
                _context.SaveChanges();
                int videoId = video.Id;
                VideoCategoryMapping videoCategoryMapping = new VideoCategoryMapping
                {
                    VideoId = videoId,
                    Video = video,
                    CategoryId = Convert.ToInt32(videoDto.CategoryId)
                };
                VideoBrandMapping videoBrandMapping = new VideoBrandMapping
                { 
                    VideoId = videoId,
                    Video = video,
                    BrandId = Convert.ToInt32(videoDto.BrandId)

                };
                _context.Add(videoCategoryMapping);
                _context.Add(videoBrandMapping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            return View(videoDto);
        }
    }
}