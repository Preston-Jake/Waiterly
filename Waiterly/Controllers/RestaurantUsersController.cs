using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Waiterly.Data;
using Waiterly.Models;

namespace Waiterly.Controllers
{
    public class RestaurantUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RestaurantUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestaurantUsers.ToListAsync());
        }

        // GET: RestaurantUsers/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: RestaurantUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestaurantUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,RestaurantId")] RestaurantUser restaurantUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantUser);
        }

        // GET: RestaurantUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantUser = await _context.RestaurantUsers.FindAsync(id);
            if (restaurantUser == null)
            {
                return NotFound();
            }
            return View(restaurantUser);
        }

        // POST: RestaurantUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,RestaurantId")] RestaurantUser restaurantUser)
        {
            if (id != restaurantUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantUserExists(restaurantUser.Id))
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
