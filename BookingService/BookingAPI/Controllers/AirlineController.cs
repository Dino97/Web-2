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
        public async Task<ActionResult<IEnumerable<object>>> GetAirlines()
        {
            var airlines = await dbContext.Airlines.Include(a => a.Logo).Select(a => new
            {
                a.Name,
                Logo = "data:image/png;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(a.Logo.ImageLocation))
            }).ToListAsync();

            return airlines;
        }

        [HttpGet]
        [Route("GetQuickReservations")]
        public async Task<ActionResult<IEnumerable<object>>> GetQuickReservations(string airline)
        {
            List<Flight> flights = await dbContext.Flights.Where(f => f.Airline.Name == airline).ToListAsync();

            return flights;
        }
    }
}
