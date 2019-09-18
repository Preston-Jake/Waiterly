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

namespace Waiterly.Controllers
{
    public class WagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        // GET: Wages
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        [Route("Restaurants/{restaurantId}/Payroll")]
        public async Task<IActionResult> Index(int restaurantId)
        {
            
            ViewBag.LoginUser = await GetUserAsync(); 
            var rUsers = _context.RestaurantUsers.Include(u => u.User).Where(u => u.RestaurantId == restaurantId).ToList();
            var wages = _context.Wages.Include(w => w.User).ToList();
            var payroll = new List<Wage>();
            foreach (var user in rUsers)
            {
                foreach (var wage in wages)
                {
                    if (wage.RestaurantId == restaurantId && wage.UserId == user.UserId)
                    {
                        payroll.Add(wage);
                    }
                }
            }
            return View(payroll);
        }

        // GET: Wages/Details/5
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        [Route("Restaurants/{restaurantId}/Payroll/{wageId}")]
        public async Task<IActionResult> Details(int? wageId)
        {
            if (wageId == null)
            {
                return NotFound();
            }

            var wage = await _context.Wages
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == wageId);
            if (wage == null)
            {
                return NotFound();
            }

            return View(wage);
        }

        // GET: Wages/Create
        [Authorize(Roles = "Admin, Manager")]
        [Route("Restaurants/{restaurantId}/Payroll/Create")]
        public IActionResult Create(int restaurantId)
        {
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
            return View();
        }

        // POST: Wages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager")]
        [Route("Restaurants/{restaurantId}/Payroll/Create")]
        public async Task<IActionResult> Create([Bind("Id,UserId,Dollars,Hours")] Wage wage)
        {
            if (ModelState.IsValid)
            {
                var routeId = RouteData.Values["restaurantId"].ToString();
                wage.RestaurantId = Int32.Parse(routeId);
                _context.Add(wage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { restaurantId = routeId });
            }
            return View(wage);
        }

        // GET: Wages/Edit/5
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        [Route("Restaurants/{restaurantId}/Payroll/{wageId}/Edit")]
        public async Task<IActionResult> Edit(int restaurantId, int? wageId)
        {
            if (wageId == null)
            {
                return NotFound();
            }

            var wage = await _context.Wages.FindAsync(wageId);
            
            if (wage == null)
            {
                return NotFound();
            }
            var routeId = RouteData.Values["restaurantId"].ToString();            
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers.Where(u => u.Id == wage.UserId), "Id", "FullName");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Id == Int32.Parse(routeId)), "Id", "Name");
            return View(wage);
        }

        // POST: Wages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Restaurants/{restaurantId}/Payroll/{wageId}/Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Dollars,Hours, RestaurantId")] Wage wage)
        {
            var routeId = RouteData.Values["restaurantId"].ToString();

            if (id != wage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WageExists(wage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { restaurantId = routeId });
            }
            
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers.Where(u => u.Id == wage.UserId), "Id", "FullName");
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants.Where(r => r.Id == Int32.Parse(routeId)), "Id", "Name");
            return View(wage);
        }

        // GET: Wages/Delete/5
        [Authorize(Roles = "Admin, Manager")]
        [Route("Restaurants/{restaurantId}/Payroll/{wageId}/Delete")]
        public async Task<IActionResult> Delete(int? wageId)
        {
            if (wageId == null)
            {
                return NotFound();
            }

            var wage = await _context.Wages
                .FirstOrDefaultAsync(m => m.Id == wageId);
            if (wage == null)
            {
                return NotFound();
            }

            return View(wage);
        }

        // POST: Wages/Delete/5
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Restaurants/{restaurantId}/Payroll/{wageId}/Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wage = await _context.Wages.FindAsync(id);
            _context.Wages.Remove(wage);
            await _context.SaveChangesAsync();
            var routeId = RouteData.Values["restaurantId"].ToString();
            return RedirectToAction("Index", new { restaurantId = routeId });
        }

        private bool WageExists(int id)
        {
            return _context.Wages.Any(e => e.Id == id);
        }
    }
}
