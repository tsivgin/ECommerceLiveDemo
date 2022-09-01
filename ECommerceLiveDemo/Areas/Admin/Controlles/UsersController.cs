using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceLiveDemo.Models;
using ECommerceLiveDemo.Models.DTOs.AdminDto;

namespace ECommerceLiveDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly SHOPContext _context;

        public UsersController(SHOPContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Id,UserName,Password,Email,FirstName,LastName,BirthDate,Gender,MobilePhoneNo,CreateDate,UpdateDate,LastSignOnDate")]
            User user)
        {
            if (ModelState.IsValid)
            {
                user.CreateDate = DateTime.UtcNow;
                user.UpdateDate = DateTime.UtcNow;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "Id,UserName,Password,Email,FirstName,LastName,BirthDate,Gender,MobilePhoneNo,CreateDate,UpdateDate,LastSignOnDate")]
            User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.UpdateDate = DateTime.UtcNow;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: Users/AddRole/5
        public async Task<IActionResult> AddRole(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var userRole = _context.UserRoles.ToList();
            AddUserRoleDto addUserRoleDto = new AddUserRoleDto
            {
                UserUserRoleMappings = user.UserUserRoleMappings,
                UserRoles = userRole,
                Email = user.Email,
                Id = user.Id
            };
            return View(addUserRoleDto);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(int id, [Bind("Id,Email")] AddUserRoleDto userRoleDto,
            string[] selectedRoles)
        {
            if (id != userRoleDto.Id)
            {
                return NotFound();
            }

            var user = _context.Users.FirstOrDefault(i => i.Id == id);

            try
            {
                var userRoles = user?.UserUserRoleMappings.Select(i => i.UserRole.Name).ToList();
                foreach (var role in selectedRoles)
                {
                    if (userRoles == null || userRoles.Contains(role)) continue;
                    UserUserRoleMapping userUserRoleMapping = new UserUserRoleMapping
                    {
                        UserId = user?.Id,
                        UserRoleId = _context.UserRoles.FirstOrDefault(i => i.Name == role)?.Id
                    };
                    _context.Add(userUserRoleMapping);
                }

                if (userRoles != null)
                    foreach (var userRole in userRoles)
                    {
                        if (selectedRoles.Contains(userRole)) continue;
                        var activeUserRole = _context.UserUserRoleMappings.FirstOrDefault(
                            i => i.UserId == id && i.UserRole.Name == userRole);
                        if (activeUserRole != null) _context.UserUserRoleMappings.Remove(activeUserRole);
                    }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userRoleDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}