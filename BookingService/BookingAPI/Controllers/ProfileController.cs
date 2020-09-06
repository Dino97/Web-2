using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private UserManager<User> userManager;
        private BookingDb db;

        public ProfileController(BookingDbContext db, UserManager<User> userManager)
        {
            this.db = new BookingDb(db);
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET: api/Profile
        public async Task<object> GetUserProfile()
        {
            string userName = User.Claims.First(c => c.Type == "UserName").Value;
            BookingAPI.Model.User user = await userManager.FindByNameAsync(userName);

            return new
            {
                user.UserName,
                user.Email, 
                user.FirstName,
                user.LastName,
                user.City,
                user.PhoneNumber
            };
        }

        [HttpGet("{id}")]
        public string GetProfileName(int id)
        {
            db.Create(new User());
            return new string[] { "Dinulja", "Isus" }[id];
        }

        // Treba HttpPost, get je da bi se moglo samo ukucati kao URL i izvrsiti
        [HttpGet]
        [Route("RegisterDefaultUser")]
        public void Create()
        {
            if (db.Read<User>("Dinulja") == null)
            {
                db.Create(new User()
                {
                    FirstName = "Dino",
                    LastName = "Tabakovic",
                    /*Username = "Dinulja",
                    Password = "1234",
                    UserType = UserType.Admin*/                
                });
            }
        }
        //[Authorize(Roles = "Admin, Customerwa")]
    }
}
