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
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<Helper> Helpers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<HelperCategory> HelperCategories { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }

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
                    new HelperCategory { Id = 1, CategoryName = "Cctv", CategoryDescription = "CCTV Installation and Fixing" },
                    new HelperCategory { Id = 2, CategoryName = "NetworkPlanning", CategoryDescription = "Network Planning and Troubleshooting" },
                    new HelperCategory { Id = 3, CategoryName = "Pabx", CategoryDescription = "PABX - Private Automatic Issues" },
                    new HelperCategory { Id = 4, CategoryName = "Cisco", CategoryDescription = "Cisco Routing - Service Maintenance" },
                    new HelperCategory { Id = 5, CategoryName = "IT", CategoryDescription = "IT and other projects" },
                    new HelperCategory { Id = 6, CategoryName = "OfficeRelocation", CategoryDescription = "Office Relocation IT Setup" },
                    new HelperCategory { Id = 7, CategoryName = "OfficeNewSetup", CategoryDescription = "Office New IT Setup" },
                    new HelperCategory { Id = 8, CategoryName = "HardwareRepair", CategoryDescription = "Basic Hardware Repairing" }
                );
            builder.Entity<TicketStatus>().HasData(
                    new TicketStatus { Id = 1, Status = "Help has been equested" },
                    new TicketStatus { Id = 2, Status = "Help is under process" },
                    new TicketStatus { Id = 3, Status = "Help has been completed successfully" }
                );
        }

    }
}
