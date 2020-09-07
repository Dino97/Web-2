using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private UserManager<User> userManager;

        public AdminController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles ="SystemAdmin")]
        [Route("NewAdmin")]
        //POST: api/Admin/NewAdmin
        public async Task<IActionResult> RegisterAdmin(AdminModel model)
        {
            string role;
            
            User user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                PhoneNumber = model.PhoneNumber
            };

            if(model.AdminType == "Flight")
            {
                role = "AirlineAdmin";
            }
            else
            {
                role = "RentACarAdmin";
            }

            try
            {
                var result = await userManager.CreateAsync(user, model.Password);
                await userManager.AddToRoleAsync(user, role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
