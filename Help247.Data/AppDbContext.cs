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
        }

    }
}
