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
        /*public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedAdmin(userManager);
        }*/

        public async static Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new string[] { "SystemAdmin", "RegularUser", "RentACarAdmin", "AirlineAdmin" };

            foreach (string role in roles)
            {
                if (!(await roleManager.RoleExistsAsync(role)))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole { Name = role, NormalizedName = role.ToUpper() });

                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create role");
                    }
                }
            }
        }
        public async static void SeedAdmin(UserManager<User> userManager)
        {
            if((await userManager.FindByNameAsync("admin")) == null)
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

                IdentityResult result = await userManager.CreateAsync(user, "admin1");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SystemAdmin").Wait();
                }
            }
        }
    }
}
