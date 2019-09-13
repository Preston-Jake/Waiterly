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
using Waiterly.ViewModels.UserTableViewModel;

namespace Waiterly.Controllers
{
    [Authorize(Roles = "Admin, Manager, Waiter, Host")]
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
        // GET: UserTables
        //var viewModel = new StudentInstructorViewModel();
        //viewModel.Students = GetAllStudents();
        //viewModel.Instructors = GetAllInstructors();

        public async Task<IActionResult> Index()
        {
            //get usertables where the userTable.RestaurantId = the login users RestaunantUser.RestaunantID are the same 

            //login user
            var user = await GetUserAsync();
            // where the login in user is join on restaurant
            var userRestaurants = _context.RestaurantUsers.Where(ru => ru.UserId == user.Id).ToList();
            //list of tables
            var Tables = _context.Tables.ToList();
            // list of assigned tables
            var userTables = _context.UserTables.Include(ut => ut.Table).ToList();
            // list of all tables in the restaurant
            var restaurantTables = new List<Table>();
            //list of all assigned table in restaurant 
            var assignedTables = new List<UserTable>();

            //foreach(var uTable in userTables)
            //{
            //    foreach(var ru in userRestaurants)
            //    {
            //        if (uTable.Table.RestaurantId == )
            //        {

            //        }
            //    }
            //}

            //foreach(var table in Tables)
            //{
            //    foreach(var restaurant in userRestaurants)
            //    {
            //        if (table.RestaurantId == restaurant.RestaurantId)
            //        {
            //            restaurantTables.Add(table);
            //        }
            //    }
            //}

            //foreach (var aTable in userTables )
            //{
            //    foreach(var rTable in restaurantTables)
            //    {
            //        if(aTable.UserId == rTable.)
            //    }
            //}

            


            var viewModel = new UserTableViewModel()
            { };
                //UserTables = await _context.UserTables.Include(ut => ut.User).Include(ut => ut.Table).ToListAsync(),

            

            return View(viewModel);
        }


        // GET: UserTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // GET: UserTables/Create
        [Authorize(Roles = "Admin, Manager, Host")]
        public IActionResult Create()
        {
            ViewData["Users"] = new SelectList(_context.ApplicationUsers, "Id", "FullName");
            ViewData["Tables"] = new SelectList(_context.Tables, "Id", "TableNumber");
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Manager, Host")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TableId")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTable);
        }

        // GET: UserTables/Edit/5
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Manager, Host")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TableId")] UserTable userTable)
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
                return RedirectToAction(nameof(Index));
            }
            return View(userTable);
        }

        // GET: UserTables/Delete/5
        [Authorize(Roles = "Admin, Manager, Host")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [Authorize(Roles = "Admin, Manager, Host")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTable = await _context.UserTables.FindAsync(id);
            _context.UserTables.Remove(userTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTableExists(int id)
        {
            return _context.UserTables.Any(e => e.Id == id);
        }
    }
}
