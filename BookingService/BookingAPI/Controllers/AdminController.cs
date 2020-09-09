using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        BookingDbContext dbContext;
        private UserManager<User> userManager;

        public AdminController(UserManager<User> userManager, BookingDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles ="SystemAdmin")]
        [Route("NewAdmin")]
        //POST: api/Admin/NewAdmin
        public async Task<IActionResult> RegisterAdmin(AdminModel model)
        {
            User user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                PhoneNumber = model.PhoneNumber
            };

            try
            {
                var result = await userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    EntityEntry<Image> entityEntry = dbContext.Add(new Image()
                    {
                        ImageData = Convert.FromBase64String(model.CompanyLogo.Split(',')[1]),
                        ImageTitle = model.CompanyName + " Logo"
                    });

                    dbContext.SaveChanges();

                    if (model.CompanyType == "Airline")
                    {
                        await userManager.AddToRoleAsync(user, "AirlineAdmin");
                        // dodaj u Airlines;
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "RentACarAdmin");

                        dbContext.RentalAgencies.Add(new RentalAgency()
                        {
                            AdminId = user.Id,
                            Description = model.CompanyDescription,
                            Name = model.CompanyName,
                            LogoId = entityEntry.Entity.Id
                        });

                        dbContext.SaveChanges();
                    }
                }
   
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
