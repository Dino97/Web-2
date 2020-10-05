using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private BookingDbContext dbContext;

        public CarController(BookingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = "RentACarAdmin")]
        [Route("GetCars")]
        // GET: api/Car/GetCars
        public async Task<IActionResult> GetCars([FromQuery]string stringId)
        {
            int branchId;
            Int32.TryParse(stringId, out branchId);

            RentalAgencyBranch branch = await dbContext.RentalAgencyBranches
                .Include(rab => rab.Cars)
                .FirstOrDefaultAsync(rab => rab.Id == branchId);

            if (branch != null)
            {
                foreach (Car car in branch.Cars)
                {
                    string[] dbImage = car.Image.Split('%');
                    byte[] image = await System.IO.File.ReadAllBytesAsync(dbImage[0]);
                    car.Image = "data:image/" + dbImage[1] + ";base64," + Convert.ToBase64String(image);
                }

                return Ok(branch.Cars);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Authorize(Roles = "RentACarAdmin")]
        [Route("AddCar")]
        // POST: api/Car/GetCars
        public async Task<IActionResult> AddCar([FromBody]CarModel model)
        {
            string location = AppDomain.CurrentDomain.BaseDirectory + model.Brand.Replace(" ", "").ToLower() + model.Model.Replace(" ", "").ToLower();
            
            try
            {
                System.IO.File.WriteAllBytes(location, Convert.FromBase64String(model.Image.Split(',')[1]));
            }
            catch (Exception)
            {
                
            }

            string dataType = model.Image.Split(';')[0].Split('/')[1];
            location += "%" + dataType;

            Car car = new Car
            {
                RentalAgencyBranchId = model.BranchId,
                Airconditioner = model.Airconditioner == "true" ? true : false,
                Automatic = model.Automatic == "true" ? true : false,
                Brand = model.Brand,
                Model = model.Model,
                PricePerDay = model.PricePerDay,
                NumberOfPassengers = model.NumberOfPassengers,
                Drive = model.Drive,
                Image = location
            };

            try
            {
                var result = await dbContext.Cars.AddAsync(car);

                dbContext.SaveChanges();

                result.Entity.Image = model.Image;

                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchResults")]
        public async Task<IActionResult> Search([FromQuery]CarSearchModel model)
        {
            model.PickupLocation.Trim();
            model.PickupLocation = model.PickupLocation.Replace(", ", ",");

            if(model.FromTime == null || model.FromTime == "null")
            {
                model.FromTime = "09:00";
            }

            if(model.ToTime == null || model.ToTime == "null")
            {
                model.ToTime = "18:00";
            }

            DateTime from = String2Date(model.FromDate, model.FromTime);
            DateTime toReturn = String2Date(model.ToDate, model.ToTime);
            DateTime to = toReturn;

            if(model.SameDrop == "false")
            {
                to = to.AddDays(2);
            }

            var branches = await dbContext.RentalAgencyBranches
                .Include(branch => branch.Location)
                .Include(branch => branch.Cars)
                    .ThenInclude(car => car.Reserved)
                .ToListAsync();

            List<RetCar> retValue = new List<RetCar>();

            foreach (RentalAgencyBranch branch in branches)
            {
                if (model.PickupLocation.Contains(","))
                {
                    string[] pickupArray = model.PickupLocation.Split(',');
                    if(pickupArray[0].ToLower() != branch.Location.Country.ToLower() 
                        || pickupArray[1].ToLower() != branch.Location.City.ToLower())
                    {
                        continue;
                    }
                }
                else if(model.PickupLocation.ToLower() != branch.Location.Country.ToLower() 
                    && model.PickupLocation.ToLower() != branch.Location.City.ToLower())
                {
                    continue;
                }

                foreach (Car car in branch.Cars)
                {
                    bool reserved = false;
                    foreach (Date date in car.Reserved)
                    {
                        if(date.DateReserved.Date >= from.Date && date.DateReserved.Date <= to.Date)
                        {
                            reserved = true;
                            break;
                        }
                    }

                    if (!reserved)
                    {
                        string[] dbImage = car.Image.Split('%');
                        byte[] image = await System.IO.File.ReadAllBytesAsync(dbImage[0]);
                        car.Image = "data:image/" + dbImage[1] + ";base64," + Convert.ToBase64String(image);

                        retValue.Add(new RetCar { Location = branch.Location, Car = car });
                    }
                }
            }

            return Ok(retValue);
        }

        private DateTime String2Date(string date, string time)
        {
            int year, month, day, hour, minute;

            string[] dateString = date.Split('-');
            string[] timeString = time.Split(':');

            Int32.TryParse(dateString[0], out year);
            Int32.TryParse(dateString[1], out month);
            Int32.TryParse(dateString[2], out day);
            Int32.TryParse(timeString[0], out hour);
            Int32.TryParse(timeString[1], out minute);

            return new DateTime(year, month, day, hour, minute, 0);
        }

        class RetCar
        {
            public Location Location { get; set; }
            public Car Car { get; set; }
        }
    }
}
