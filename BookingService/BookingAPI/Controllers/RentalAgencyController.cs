using System;
using System.Collections.Generic;
using System.IO;
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
        [Route("LoadAgency/")]
        // GET: api/RentalAgency/LoadAgency
        public async Task<object> GetAgency([FromQuery]string companyName)
        {
            // var rentalAgency = await dbContext.RentalAgencies.Where(ra => ra.Name == companyName).SingleAsync();
            var rentalAgency = await dbContext.RentalAgencies.Include(ra => ra.Logo).FirstOrDefaultAsync(ra => ra.Name == companyName);

            if(rentalAgency == null)
            {
                return NotFound();
            }

            byte[] image = await System.IO.File.ReadAllBytesAsync(rentalAgency.Logo.ImageLocation);  

            return Ok(new { 
                name = rentalAgency.Name,
                description = rentalAgency.Description,
                logo = "data:image/png;base64," + Convert.ToBase64String(image) 
            });
        }

        [HttpGet]
        [Route("LoadAgencies")]
        // GET: api/RentalAgency/LoadAgencies
        public async Task<IActionResult> LoadAgencies()
        {
            var agencies = await dbContext.RentalAgencies.Include(ra => ra.Logo)
                .Select(ra => new 
                {
                    ra.Name,
                    Logo = "data:image/png;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(ra.Logo.ImageLocation))
                })
                .ToListAsync();

            return Ok(agencies);
        }
    }
}
