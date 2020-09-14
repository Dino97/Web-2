using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
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
            var rentalAgency = await dbContext.RentalAgencies
                .Include(ra => ra.Logo)
                .Include(ra => ra.Branches)
                    .ThenInclude(branch => branch.Location)
                .FirstOrDefaultAsync(ra => ra.Name == companyName);

            if(rentalAgency == null)
            {
                return NotFound();
            }

            byte[] image = await System.IO.File.ReadAllBytesAsync(rentalAgency.Logo.ImageLocation);  

            return Ok(new { 
                name = rentalAgency.Name,
                description = rentalAgency.Description,
                logo = "data:image/png;base64," + Convert.ToBase64String(image),
                branches = rentalAgency.Branches
            });
        }

        [HttpGet]
        [Route("LoadAgencies")]
        // GET: api/RentalAgency/LoadAgencies
        public async Task<IActionResult> LoadAgencies()
        {
            var agencies = await dbContext.RentalAgencies
                .Include(ra => ra.Logo)
                .Select(ra => new 
                {
                    ra.Name,
                    Logo = "data:image/png;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(ra.Logo.ImageLocation))
                })
                .ToListAsync();

            return Ok(agencies);
        }

        [HttpGet]
        [Authorize(Roles = "RentACarAdmin")]
        [Route("LoadBranches")]
        // GET: api/RentalAgency/LoadBranches
        public async Task<IActionResult> LoadBranches()
        {
            string admin = User.Claims.First(claim => claim.Type == "UserName").Value;

            var agency = await dbContext.RentalAgencies
                .Include(ra => ra.Branches)
                    .ThenInclude(ra => ra.Location)
                .Select(ra => new 
                { 
                    ra.AdminUserName,
                    ra.Branches                
                })
                .FirstOrDefaultAsync(ra => ra.AdminUserName == admin);

            return Ok(agency.Branches);
        }

        [HttpPost]
        [Authorize(Roles = "RentACarAdmin")]
        [Route("AddBranch")]
        public async Task<IActionResult> AddBranch([FromBody]BranchModel model)
        {
            string admin = User.Claims.First(claim => claim.Type == "UserName").Value;

            var agency = await dbContext.RentalAgencies.FirstOrDefaultAsync(ra => ra.AdminUserName == admin);

            RentalAgencyBranch branch = new RentalAgencyBranch 
            {
                ContactNumber = model.ContactNumber,
                NearAirpot = model.NearAirport == "true" ? true : false,
                WorkTimeFrom = String2Time(model.WorksFrom),
                WorkTimeTo = String2Time(model.WorksTo),
                Location = new Location
                {
                    Adress = model.Address,
                    Country = model.Country,
                    City = model.City
                },
                AgencyId = agency.Id
            };

            try
            {
                var result = await dbContext.RentalAgencyBranches.AddAsync(branch);
                //dbContext.Entry(agency).State = EntityState.Modified;

                await dbContext.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private DateTime String2Time(string time)
        {
            int hours, minutes;
            
            Int32.TryParse(time.Split(':')[0], out hours);
            Int32.TryParse(time.Split(':')[1], out minutes);
            
            DateTime retVal = DateTime.Now.AddHours(hours);
            retVal = DateTime.Now.AddMinutes(minutes);

            return retVal;
        }
    }
}
