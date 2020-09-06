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
        public static void SeedAdmin(UserManager<User> userManager)
        {
            if(userManager.FindByNameAsync("admin").Result == null)
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
