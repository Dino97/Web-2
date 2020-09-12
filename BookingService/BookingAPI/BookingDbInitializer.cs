using BookingAPI.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI
{
    public static class BookingDbInitializer
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedAdmin(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new string[] { "SystemAdmin", "RegularUser", "RentACarAdmin", "AirlineAdmin" };

            foreach (string role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    var result = roleManager.CreateAsync(new IdentityRole { Name = role, NormalizedName = role.ToUpper() }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create role");
                    }
                }
            }
        }
        public static void SeedAdmin(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                User user = new User
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Administrator",
                    LastName = "Administratorovic",
                    City = "AdminGrad",
                    PhoneNumber = "+381600000001"
                };

                IdentityResult result = userManager.CreateAsync(user, "admin1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SystemAdmin").Wait();
                }
            }
        }
    }
}
