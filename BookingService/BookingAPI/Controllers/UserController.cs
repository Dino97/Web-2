using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Model;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST:  api/User/Register
        public async Task<Object> PostUser(UserModel model)
        {
            BookingAPI.Model.User user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                City = model.City
            };

            try
            {
                var result = await userManager.CreateAsync(user, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
