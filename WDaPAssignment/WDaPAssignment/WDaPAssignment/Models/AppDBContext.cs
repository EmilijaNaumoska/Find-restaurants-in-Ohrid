using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WDaPAssignment.Models
{

    public class AppReviewDBContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>,
       int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
       IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppReviewDBContext(DbContextOptions<AppReviewDBContext> options)
           : base(options)
        {
        }
      
        public DbSet<CustomerReview> CustomerReview { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<IdentityUser<int>>(entity =>
            {
                entity.ToTable(name: "User");
                entity.Property(e => e.Id).HasColumnName("UserId");
            });
             builder.Entity<IdentityUser<int>>().Ignore(c => c.EmailConfirmed)
                                         .Ignore(c => c.LockoutEnabled)
                                         .Ignore(c => c.PhoneNumber)
                                         .Ignore(c => c.TwoFactorEnabled)
                                         .Ignore(c => c.PhoneNumberConfirmed)
                                         .Ignore(c => c.LockoutEnabled)
                                         .Ignore(c => c.PhoneNumberConfirmed)
                                         .Ignore(c => c.ConcurrencyStamp)
                                          .Ignore(c => c.AccessFailedCount)
                                          .Ignore(c => c.AccessFailedCount)
                                         .Ignore(c => c.LockoutEnd);
            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.Property(e => e.Id).HasColumnName("RoleId");
            });
            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles");

            });

          builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins");

            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

             builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

        }

    }
}
