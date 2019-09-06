using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Waiterly.Models;

namespace Waiterly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantUser> RestaurantUsers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<Wage> Wages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new {Id = "1" , Name = "Admin", NormalizeName = "ADMIN" },
                new {Id = "2" , Name = "Host", NormalizeName = "HOST" },
                new {Id = "3" , Name = "Waiter", NormalizeName = "WAITER" }
                );
        }

    }
}
