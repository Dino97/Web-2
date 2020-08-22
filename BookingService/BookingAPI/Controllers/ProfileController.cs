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

        [HttpPost]
        public void Create()
        {

        }
    }
}
