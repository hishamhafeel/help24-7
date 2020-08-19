using Help247.Common.Utility;
using Help247.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
        public DbSet<SubService> SubServices { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region set unique property
            builder.Entity<Helper>().HasIndex(x => x.Email).IsUnique();
            builder.Entity<Helper>().HasIndex(x => x.PhoneNo).IsUnique();
            builder.Entity<Helper>().HasIndex(x => x.MobileNo).IsUnique();

            builder.Entity<Customer>().HasIndex(x => x.Email).IsUnique();
            builder.Entity<Customer>().HasIndex(x => x.PhoneNo).IsUnique();

            builder.Entity<HelperCategory>().HasIndex(x => x.Name).IsUnique();

            builder.Entity<Image>().HasIndex(x => x.ImageUrl).IsUnique();
            #endregion

            #region seed roles
            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "2", Name = "Helper", NormalizedName = "HELPER" },
                    new IdentityRole { Id = "3", Name = "Customer", NormalizedName = "CUSTOMER" },
                    new IdentityRole { Id = "4", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
                );
            #endregion

            #region seed SuperAdmin
            var adminId = "431fca8c-0fba-407e-846f-2248e7d139eb";
            User adminUser = new User
            {
                Id = adminId,
                UserName = "superadmin",
                Email = "superadmin@admin.com",
                NormalizedEmail = "superadmin@admin.com".ToUpper(),
                NormalizedUserName = "superadmin".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = false,
                IsAdmin = true,
                RecordState = Enums.RecordState.Active,

            };
            

            PasswordHasher<User> ph = new PasswordHasher<User>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "Admin@1234");

            builder.Entity<User>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "4",
                UserId = adminId
            });
            #endregion

            #region seed TicketStatus
            builder.Entity<TicketStatus>().HasData(
                    new TicketStatus { Id = 1, Status = "Help has been requested" },
                    new TicketStatus { Id = 2, Status = "Help is under process" },
                    new TicketStatus { Id = 3, Status = "Help has been completed successfully" },
                    new TicketStatus { Id = 4, Status = "Help has been cancelled" }
                );
            #endregion

            #region seed HelpCentre
            builder.Entity<HelpCentre>().HasData(
                   new HelpCentre { Id = 1, Title = "Terms & Conditions" },
                   new HelpCentre { Id = 2, Title = "Privacy Policy" },
                   new HelpCentre { Id = 3, Title = "FAQ" }
               );
            #endregion

            builder.Entity<HelpCentre>()
                 .Property(b => b.Topics)
                 .HasConversion(
                 v => JsonConvert.SerializeObject(v),
                 v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));

            
        }

    }
}
