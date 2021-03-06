﻿using System;
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
//?? is there a way to save the restaurant id in the url and only show data related to that restaurant
//I would have the change the routing
// I know that it would look like restaurant/id/userTables to see the correct data but getting their is thwe question 
//I might require a dictionary for paramaters 
//other than than i know on manage click from the restaurant index view is where that data will be intilized the url need to read more into.. might cut down on page logic anyway

namespace Waiterly.Controllers
{
    public class UserTablesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public UserTablesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }
        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        private Task<List<UserTable>> GetRestaurantTables(int Id)
        {
            return _context.UserTables.Where(ut => ut.RestaurantId == Id).ToListAsync();
        }

        // GET: UserTables
        [Route("Restaurants/{restaurantId}/UserTables")]
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        public async Task<IActionResult> Index(int restaurantId)
        {
            ViewBag.LoginUser = await GetUserAsync();
            var applicationDbContext = _context.UserTables.Include(u => u.Restaurant).Include(u => u.User).Where(u => u.RestaurantId == restaurantId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserTables/Details/5
        [Route("Restaurants/{restaurantId}/UserTables/{tableId}")]
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        public async Task<IActionResult> Details(int restaurantId, int? tableId )
        {
            if (tableId == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .Include(u => u.Restaurant)
                .Include(u => u.User)
                .Where(u => u.RestaurantId == restaurantId)
                .FirstOrDefaultAsync(m => m.Id == tableId);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }
        
        // GET: UserTables/Create
        [Route("Restaurants/{restaurantId}/UserTables/Create")]
        [Authorize(Roles = "Admin, Manager, Host")]
        public IActionResult Create(int restaurantId)
        {
            var rUsers = _context.RestaurantUsers.Include(ru => ru.User).ToList();
            var employees = new List<ApplicationUser>();
            foreach(var u in rUsers)
            {
                
                if(u.RestaurantId == restaurantId)
                {
                    employees.Add(u.User);
                }
            }

            ViewData["UserId"] = new SelectList(employees, "Id", "FullName");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Id == restaurantId), "Id", "Name");
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Restaurants/{restaurantId}/UserTables/Create")]
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> Create([Bind("Id,UserId,TableNumber,Seats,RestaurantId")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTable);
                await _context.SaveChangesAsync();
                var routeId = RouteData.Values["restaurantId"].ToString();
                return RedirectToAction("Index", new { restaurantId = routeId });
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Address", userTable.RestaurantId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userTable.UserId);
            return View(userTable);
        }

        // GET: UserTables/Edit/5
        [Route("Restaurants/{restaurantId}/UserTables/Edit/{tableId}")]
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> Edit(int restaurantId , int? tableId)
        {
            if (tableId == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables.FindAsync(tableId);
            if (userTable == null)
            {
                return NotFound();
            }
            var rUsers = _context.RestaurantUsers.Include(ru => ru.User).ToList();
            var employees = new List<ApplicationUser>();
            foreach (var u in rUsers)
            {
                if (u.RestaurantId == restaurantId)
                {
                    employees.Add(u.User);
                }
            }
            ViewData["UserId"] = new SelectList(employees, "Id", "FullName");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Id == restaurantId), "Id", "Name");
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Restaurants/{restaurantId}/UserTables/Edit/{tableId}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TableNumber,Seats,RestaurantId")] UserTable userTable)
        {
            if (id != userTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTableExists(userTable.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { restaurantId = userTable.RestaurantId });
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Address", userTable.RestaurantId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userTable.UserId);
            return View(userTable);
        }

        [HttpPost, ActionName("Unassign")]
        [ValidateAntiForgeryToken]
        [Route("Restaurants/{restaurantId}/UserTables")]
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> Unassign(int unassignId )
        {
            var routeId = RouteData.Values["restaurantId"].ToString();


            if (ModelState.IsValid)
            {
                    var unassignTables = _context.UserTables.Where(ut => ut.Id == unassignId);
                    var unassignTable = new UserTable();
                    foreach(var table in unassignTables)
                    {
                    unassignTable = table;
                    }
                    unassignTable.UserId = null;
                    _context.UserTables.Update(unassignTable);
                    await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { restaurantId = routeId });
            }
            return RedirectToAction("Index", new { restaurantId = routeId });

        }
        // GET: UserTables/Delete/5
        [Route("Restaurants/{restaurantId}/UserTables/Delete/{tableId}")]
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> Delete(int restaurantId , int? tableId)
        {
            if (tableId == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .Include(u => u.Restaurant)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == tableId);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Restaurants/{id}/UserTables/Delete/{tableId}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTable = await _context.UserTables.FindAsync(id);
            _context.UserTables.Remove(userTable);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { restaurantId = userTable.RestaurantId });
        }

        private bool UserTableExists(int id)
        {
            return _context.UserTables.Any(e => e.Id == id);
        }
    }
}
