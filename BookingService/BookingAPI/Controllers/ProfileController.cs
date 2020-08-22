using Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private BookingDb db;



        public ProfileController(BookingDbContext db)
        {
            this.db = new BookingDb(db);
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
                    Username = "Dinulja",
                    Password = "1234",
                    UserType = UserType.Admin
                });
            }
        }
    }
}
