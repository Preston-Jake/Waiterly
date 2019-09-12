using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Waiterly.Data;
using Waiterly.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace Waiterly.Controllers
{
    [Authorize]
    public class RestaurantUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public RestaurantUsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
        // GET: RestaurantUsers
        // return a list of employees where the Login User Also Works
        public async Task<IActionResult> Index()
        {
            var user = await GetUserAsync();
            var rUsers = _context.RestaurantUsers
                .Include(ru => ru.Restaurant)
                .Include(ru => ru.User)
                .Where(ru => ru.UserId == user.Id);
                

            return View(await _context.RestaurantUsers
                .Include(ru => ru.Restaurant)
                .Include(ru => ru.User)
                .Where(ru => ru.UserId == user.Id)
                .ToListAsync()); 
        }
 
        // GET: RestaurantUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantUser = await _context.RestaurantUsers
                .Include(ru => ru.Restaurant)
                .Include(ru => ru.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantUser == null)
            {
                return NotFound();
            }

            return View(restaurantUser);
        }

        // GET: RestaurantUsers/Create
        public async Task<IActionResult> Create()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            ViewData["Restaurants"] = new SelectList(_context.Restaurants, "Id", "Name");
            return View();
        }

        // POST: RestaurantUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RestaurantId")] RestaurantUser restaurantUser)
        {
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                var user = await GetUserAsync();
                restaurantUser.UserId = user.Id;
                _context.Add(restaurantUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "RestaurantId", restaurantUser.RestaurantId);
            return View(restaurantUser);
        }

        // GET: RestaurantUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantUser = await _context.RestaurantUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurantUser == null)
            {
                return NotFound();
            }

            return View(restaurantUser);
        }

        // POST: RestaurantUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantUser = await _context.RestaurantUsers.FindAsync(id);
            _context.RestaurantUsers.Remove(restaurantUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantUserExists(int id)
        {
            return _context.RestaurantUsers.Any(e => e.Id == id);
        }
    }
}
