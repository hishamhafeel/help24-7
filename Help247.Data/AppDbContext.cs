using Help247.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext>  options) : base(options)
        {
        }

        public DbSet<Helper> Helpers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<HelperCategory> HelperCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Helper>().HasIndex(x => x.Email).IsUnique();
            builder.Entity<Helper>().HasIndex(x => x.PhoneNo).IsUnique();

            builder.Entity<Customer>().HasIndex(x => x.Email).IsUnique();
            builder.Entity<Customer>().HasIndex(x => x.PhoneNo).IsUnique();

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "2", Name = "Helper", NormalizedName = "HELPER" },
                    new IdentityRole { Id = "3", Name = "Customer", NormalizedName = "CUSTOMER" }
                );
            builder.Entity<HelperCategory>().HasData(
                    new HelperCategory { Id = 1, CategoryName = "None", CategoryDescription = "Category not assigned" },
                    new HelperCategory { Id = 2, CategoryName = "Cctv", CategoryDescription = "CCTV Installation and Fixing" },
                    new HelperCategory { Id = 3, CategoryName = "NetworkPlanning", CategoryDescription = "Network Planning and Troubleshooting" },
                    new HelperCategory { Id = 4, CategoryName = "Pabx", CategoryDescription = "PABX - Private Automatic Issues" },
                    new HelperCategory { Id = 5, CategoryName = "Cisco", CategoryDescription = "Cisco Routing - Service Maintenance" },
                    new HelperCategory { Id = 6, CategoryName = "IT", CategoryDescription = "IT and other projects" },
                    new HelperCategory { Id = 7, CategoryName = "OfficeRelocation", CategoryDescription = "Office Relocation IT Setup" },
                    new HelperCategory { Id = 8, CategoryName = "OfficeNewSetup", CategoryDescription = "Office New IT Setup" },
                    new HelperCategory { Id = 9, CategoryName = "HardwareRepair", CategoryDescription = "Basic Hardware Repairing" }
                );
        }

    }
}
