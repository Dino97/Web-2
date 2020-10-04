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
using Microsoft.EntityFrameworkCore.Infrastructure;

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
                .Include(ra => ra.Branches)
                    .ThenInclude(branch => branch.Cars)
                .FirstOrDefaultAsync(ra => ra.Name == companyName);

            if(rentalAgency == null)
            {
                return NotFound();
            }

            foreach (RentalAgencyBranch branch in rentalAgency.Branches)
            {
                foreach (Car car in branch.Cars)
                {
                    string[] dbImage = car.Image.Split('%');
                    byte[] img = await System.IO.File.ReadAllBytesAsync(dbImage[0]);
                    car.Image = "data:image/" + dbImage[1] + ";base64," + Convert.ToBase64String(img);
                }
            }

            byte[] image = await System.IO.File.ReadAllBytesAsync(rentalAgency.Logo.ImageLocation);  

            return Ok(new { 
                name = rentalAgency.Name,
                description = rentalAgency.Description,
                logo = "data:image/png;base64," + Convert.ToBase64String(image),
                branches = rentalAgency.Branches,
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
                    .ThenInclude(rab => rab.Location)
                .Include(ra => ra.Branches)
                    .ThenInclude(rab => rab.Cars)
                .Select(ra => new 
                { 
                    ra.AdminUserName,
                    ra.Branches                
                })
                .FirstOrDefaultAsync(ra => ra.AdminUserName == admin);

            foreach (RentalAgencyBranch branch in agency.Branches)
            {
                foreach (Car car in branch.Cars)
                {
                    string[] dbImage = car.Image.Split('%');
                    byte[] image = await System.IO.File.ReadAllBytesAsync(dbImage[0]);
                    car.Image = "data:image/" + dbImage[1] + ";base64," + Convert.ToBase64String(image);
                }
            }

            return Ok(agency.Branches);
        }

        [HttpPost]
        [Authorize(Roles = "RentACarAdmin")]
        [Route("AddBranch")]
        // POST: api/RentalAgency/AddBranch
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
                RentalAgencyId = agency.Id
            };

            try
            {
                var result =  await dbContext.RentalAgencyBranches.AddAsync(branch);
                //dbContext.Entry(agency).State = EntityState.Modified;

                dbContext.SaveChanges();

                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "RentACarAdmin")]
        [Route("UpdateBranch")]
        // PUT: api/RentalAgency/UpdateBranch
        public async Task<IActionResult> UpdateBranch([FromBody]UpdateBranchModel branchModel)
        {
            RentalAgencyBranch branch = await dbContext.RentalAgencyBranches
                .Include(rab => rab.Location)
                .FirstOrDefaultAsync(rab => rab.Id == branchModel.Id);

            if(branch == null)
            {
                return NotFound();
            }

            branch.NearAirpot = branchModel.NearAirport == "true" ? true : false;
            branch.Location.Adress = branchModel.Address;
            branch.Location.City = branchModel.City;
            branch.Location.Country = branchModel.Country;

            if(!TimeComparator(branchModel.WorksFrom, branch.WorkTimeFrom))
            {
                branch.WorkTimeFrom = String2Time(branchModel.WorksFrom);
            }

            if (!TimeComparator(branchModel.WorksTo, branch.WorkTimeTo))
            {
                branch.WorkTimeTo = String2Time(branchModel.WorksTo);
            }

            dbContext.RentalAgencyBranches.Update(branch);

            dbContext.SaveChanges();

            return NoContent();
        }

        //false ako su isti, true ako se razlikuju
        private bool TimeComparator(string s_time, DateTime d_time)
        {
            bool retVal = false;
            int hours, minutes;

            Int32.TryParse(s_time.Split(':')[0], out hours);
            Int32.TryParse(s_time.Split(':')[1], out minutes);

            if (hours != d_time.Hour || minutes != d_time.Minute)
            {
                retVal = false;
            }

            return retVal;
        }

        private DateTime String2Time(string time)
        {
            int hours, minutes;
            
            Int32.TryParse(time.Split(':')[0], out hours);
            Int32.TryParse(time.Split(':')[1], out minutes);

            DateTime retVal = DateTime.Now;
            retVal = retVal.Date + new TimeSpan(hours, minutes, 0);

            return retVal;
        }
    }
}
