using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookingAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalAgencyController : ControllerBase
    {
        private BookingDbContext dbContext;

        public RentalAgencyController(BookingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("LoadAgency")]
        // GET: api/RentalAgency/LoadAgency
        public async Task<object> GetAgency([FromBody] string companyName)
        {
            // var rentalAgency = await dbContext.RentalAgencies.Where(ra => ra.Name == companyName).SingleAsync();
            var rentalAgency = await dbContext.RentalAgencies.FirstOrDefaultAsync(ra => ra.Name == companyName);

            if(rentalAgency == null)
            {
                return NotFound();
            }

            return Ok(rentalAgency);
        }
    }
}
