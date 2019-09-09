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
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantUser> RestaurantUsers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<Wage> Wages { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                RestaurantId = 1,
                WageId = 1,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            builder.Entity<ApplicationUser>().HasData(user);
            builder.Entity<Restaurant>().HasData(
                new {Id = 1 , Name = "TestRestaurant", Phone = "16155120998", Address = "111 Test Address" }
                );
            builder.Entity<Wage>().HasData(
                new {Id = 1 , UserId = "00000000-ffff-ffff-ffff-ffffffffffff",  Dollars = 12.50 , Hours = 10.0, }
                );
            builder.Entity<Table>().HasData(
                new {Id = 1 , TableNumber = 1, Seats = 2,  RestaurantId = 1 }
                );
            builder.Entity<RestaurantUser>().HasData(
                new {Id = 1 , UserId = "00000000-ffff-ffff-ffff-ffffffffffff", RestaurantId = 1 }
                );
            builder.Entity<UserTable>().HasData(
                new { Id = 1, UserId = "00000000-ffff-ffff-ffff-ffffffffffff", TableId = 1 } 
                );

        }

    }
}

