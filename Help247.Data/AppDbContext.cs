using Help247.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<HelpCentre> HelpCentres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Helper>().HasIndex(x => x.Email).IsUnique();
            builder.Entity<Helper>().HasIndex(x => x.PhoneNo).IsUnique();
            builder.Entity<Helper>().HasIndex(x => x.MobileNo).IsUnique();

            builder.Entity<Customer>().HasIndex(x => x.Email).IsUnique();
            builder.Entity<Customer>().HasIndex(x => x.PhoneNo).IsUnique();

            builder.Entity<HelperCategory>().HasIndex(x => x.Name).IsUnique();

            builder.Entity<Image>().HasIndex(x => x.ImageUrl).IsUnique();

            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "2", Name = "Helper", NormalizedName = "HELPER" },
                    new IdentityRole { Id = "3", Name = "Customer", NormalizedName = "CUSTOMER" }
                );
            
            builder.Entity<TicketStatus>().HasData(
                    new TicketStatus { Id = 1, Status = "Help has been requested" },
                    new TicketStatus { Id = 2, Status = "Help is under process" },
                    new TicketStatus { Id = 3, Status = "Help has been completed successfully" },
                    new TicketStatus { Id = 4, Status = "Help has been cancelled" }
                );

            builder.Entity<HelperCategory>()
                .Property(b => b.ServicesProvided)
                .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));

            builder.Entity<HelpCentre>()
                 .Property(b => b.Topics)
                 .HasConversion(
                 v => JsonConvert.SerializeObject(v),
                 v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));

            builder.Entity<HelpCentre>().HasData(
                   new HelpCentre { Id = 1, Title = "Terms & Conditions" },
                   new HelpCentre { Id = 2, Title = "Privacy Policy" },
                   new HelpCentre { Id = 3, Title = "FAQ" }
               );
        }

    }
}
