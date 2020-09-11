using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookingAPI.Model;
using Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private readonly ApplicationSettings appSettings;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST:  api/User/Register
        public async Task<IActionResult> PostUser(UserModel model)
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
                await userManager.AddToRoleAsync(user, "RegisteredUser");
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(ChangeableUserData data)
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;
            User user = await userManager.FindByNameAsync(username);

            if (user == null)
                return BadRequest();

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.City = data.City;

            await userManager.UpdateAsync(user);
            return NoContent();
        }

        [HttpPost]
        [Route("Login")]
        //POST:  api/User/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            User user = await userManager.FindByNameAsync(model.UserName);

            if(user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                string token = await TokenGenerator(user, "regular");
                
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
        }

        [HttpPost]
        [Route("SocialLogin")]
        //POST:  api/User/SocialLogin
        public async Task<IActionResult> SocialLogin([FromBody]SocialLoginModel model)
        {
            if (VerifyToken(model.Provider, model.IdToken)) 
            {
                model.UserName = model.Email.Split('@')[0];
                User user = await userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    // REGISTER
                    user = new User()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    try
                    {
                        await userManager.CreateAsync(user);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new { message = ex.Message });
                    }
                }

                //LOGIN
                string token = await TokenGenerator(user, "social");

                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Unable to authenticate." });
            }
        }

        public async Task<string> TokenGenerator(User user, string loginType)
        {
            var roles = await userManager.GetRolesAsync(user);
            IdentityOptions options = new IdentityOptions();

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserName", user.UserName),
                        new Claim(options.ClaimsIdentity.RoleClaimType, roles.FirstOrDefault()),
                        new Claim("LoginType", loginType)
                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(securityToken);
        }

        private const string FacebookApiTokenInfoUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token=803053426901714|0c0ca7a71518fb0ca06e1f92fb527efb";
        private const string GoogleApitTokenIngoUrl = "https://oauth2.googleapis.com/tokeninfo?id_token={0}";

        public bool VerifyToken(string provider, string providerToken)
        {
            HttpClient httpClient = new HttpClient();
            Uri requestUri = null;

            switch (provider)
            {
                case "FACEBOOK":
                    requestUri = new Uri(string.Format(FacebookApiTokenInfoUrl, providerToken));
                    break;
                case "GOOGLE":
                    requestUri = new Uri(string.Format(GoogleApitTokenIngoUrl, providerToken));
                    break;
            }

            HttpResponseMessage httpResponse;

            try
            {
                httpResponse = httpClient.GetAsync(requestUri).Result;
            }
            catch (Exception ex)
            {
                return false;
            }

            if(httpResponse.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return true;
        }

        public class ChangeableUserData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
        }
    }
}
