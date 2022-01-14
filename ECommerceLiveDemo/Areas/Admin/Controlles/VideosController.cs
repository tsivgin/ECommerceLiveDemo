using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceLiveDemo.Models;


namespace ECommerceLiveDemo.Areas.Admin.Controlles
{
    [Area("Admin")]
    public class VideosController : Controller
    {
        private readonly SHOPContext _context;

        public VideosController(SHOPContext context)
        {
            _context = context;
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
            return View();
        }
        
        
        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FileName,FileUrl,FirstImageLink,SecondImageLink,Description")] Video video)
        {
            if (ModelState.IsValid)
            {
                //video.CreateDate = DateTime.UtcNow;
                //video.UpdateDate = DateTime.UtcNow;
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            return View(video);
        }
    }
}