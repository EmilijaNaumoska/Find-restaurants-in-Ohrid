
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDaPAssignment.Models;

namespace WDaPAssignment
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppReviewDBContext>();
                context.Database.EnsureCreated();

                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<int>>>();
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                if (!context.Users.Any(usr => usr.UserName == "manager@review.com"))
                {
                    var user = new IdentityUser<int>()
                    {
                        UserName = "manager@review.com",
                        Email = "manager@review.com",
                      
                    };

                    var userResult = _userManager.CreateAsync(user, "123456").Result;
                }
                if (!_roleManager.RoleExistsAsync("Manager").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole<int> {  Name= "Manager" }).Result;
                }
                var adminUser = _userManager.FindByEmailAsync("manager@review.com").Result;
                var adminRole = _userManager.AddToRolesAsync(adminUser, new string[] { "Manager" }).Result;
                var _adminRole = _roleManager.Roles.Where(x => x.Name == "Manager").FirstOrDefault();
                if (!context.UserRoles.Any(a => a.UserId == adminUser.Id && a.RoleId == _adminRole.Id))
                {
                    var role = _userManager.AddToRoleAsync(adminUser, _adminRole.Name).Result;
                }
                if (!_roleManager.RoleExistsAsync("Customer").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole<int> { Name = "Customer" }).Result;
                }
                context.SaveChanges();
            }
        }



    }
}
