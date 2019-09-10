using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public WagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wages
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wages.ToListAsync());
        }

        // GET: Wages/Details/5
        [Authorize(Roles = "Admin, Manager, Waiter, Host")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wage = await _context.Wages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wage == null)
            {
                return NotFound();
            }

            return View(wage);
        }

        // GET: Wages/Create
        [Authorize(Roles = "Admin, Manager" )]
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Create([Bind("Id,UserId,Dollars,Hours")] Wage wage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wage);
        }

        // GET: Wages/Edit/5
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wage = await _context.Wages.FindAsync(id);
            if (wage == null)
            {
                return NotFound();
            }
            return View(wage);
        }

        // POST: Wages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Dollars,Hours")] Wage wage)
        {
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
                return RedirectToAction(nameof(Index));
            }
            return View(wage);
        }

        // GET: Wages/Delete/5
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wage = await _context.Wages
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wage = await _context.Wages.FindAsync(id);
            _context.Wages.Remove(wage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WageExists(int id)
        {
            return _context.Wages.Any(e => e.Id == id);
        }
    }
}
