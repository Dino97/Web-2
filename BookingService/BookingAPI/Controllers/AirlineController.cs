using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private BookingDbContext dbContext;



        public AirlineController(BookingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAirlines")]
        public async Task<ActionResult<IEnumerable<Airline>>> GetAirlines()
        {
            List<Airline> airlines = await dbContext.Airlines.ToListAsync();
            return airlines;
        }
    }
}
