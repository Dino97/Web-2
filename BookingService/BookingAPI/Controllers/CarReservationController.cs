using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReservationController : ControllerBase
    {
        private BookingDbContext dbContext;
        private UserManager<User> userManager;

        public CarReservationController(BookingDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "RegularUser")]
        [Route("ReservationInfo")]
        // GET: api/CarReservation/ReservationInfo
        public async Task<IActionResult> GetInfo([FromQuery]ToReserve info)
        {
            int carId;
            Int32.TryParse(info.CarId, out carId);

            Car car = await dbContext.Cars.FindAsync(carId);

            if(car == null)
            {
                return BadRequest();
            }

            RentalAgencyBranch branch = await dbContext.RentalAgencyBranches.FindAsync(car.RentalAgencyBranchId);

            if(branch == null)
            {
                return BadRequest();
            }

            RentalAgency agency = await dbContext.RentalAgencies
                .Include(ra => ra.Branches)
                    .ThenInclude(rab => rab.Location)
                .Include(ra => ra.Logo)
                .FirstOrDefaultAsync(ra => ra.Id == branch.RentalAgencyId);

            if(agency == null)
            {
                return BadRequest();
            }

            List<Location> locations = new List<Location>();

            foreach (RentalAgencyBranch rab in agency.Branches)
            {
                if(rab.Id != branch.Id)
                {
                    locations.Add(rab.Location);
                }
            }

            int reservationLength = ResLengthCalculator(info.FromDate, info.ToDate);

            if (info.FromTime == null || info.FromTime == "null")
            {
                info.FromTime = "09:00";
            }

            if (info.ToTime == null || info.ToTime == "null")
            {
                info.ToTime = "18:00";
            }

            byte[] image = await System.IO.File.ReadAllBytesAsync(agency.Logo.ImageLocation);

            return Ok(new { 
                locations,
                logo = "data:image/png;base64," + Convert.ToBase64String(image),
                totalCost = ++reservationLength * car.PricePerDay,
                fromTime = info.FromTime,
                toTime = info.ToTime
            });
        }

        [HttpPost]
        [Authorize(Roles = "RegularUser")]
        [Route("Reserve")]
        // POST: api/CarReservation/Reserve
        public async Task<IActionResult> Reserve([FromBody]CarReservationModel model)
        {
            int DropoffLocationId = model.PickupLocationId;

            string userName = User.Claims.First(claim => claim.Type == "UserName").Value;
            User user = await userManager.FindByNameAsync(userName);

            Car car = await dbContext.Cars
                .FirstOrDefaultAsync(car => car.Id == model.CarId);

            DateTime from = String2Date(model.FromDate);
            DateTime to = String2Date(model.ToDate);

            if(model.PickupLocationId != DropoffLocationId)
            {
                to = to.AddDays(2);
            }

            DateTime iterator = from;

            var date =  await dbContext.CarDates.AddAsync(new Date { DateReserved = iterator, CarId = car.Id });

            if(date == null)
            {
                return BadRequest();
            }

            while(iterator != to)
            {
                iterator = iterator.AddDays(1);

                date = await dbContext.CarDates.AddAsync(new Date { DateReserved = iterator, CarId = car.Id });

                if (date == null)
                {
                    return BadRequest();
                }
            }

            try
            {
                var reservation = await dbContext.CarReservations.AddAsync(new CarReservation {
                    User = user,
                    Car = car,
                    PickupDate = model.FromDate,
                    PickupLocationId = model.PickupLocationId,
                    PickupTime = model.FromTime,
                    DropoffDate = model.ToDate,
                    DropoffLocationId = DropoffLocationId,
                    DropoffTime = model.ToTime,
                    Price = model.Price
                });

                dbContext.SaveChanges();

                return Ok(reservation.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Authorize(Roles = "RegularUser")]
        [Route("GetReservations")]
        // GET: api/CarReservation/GetReservations
        public async Task<IActionResult> GetReservations()
        {
            string userName = User.Claims.First(claim => claim.Type == "UserName").Value;
            User user = await userManager.FindByNameAsync(userName);

            var reservations = await dbContext.CarReservations
                .Include(res => res.User)
                .Include(res => res.Car)
                .Where(res => user.Id == res.User.Id)
                .ToListAsync();

            List<UserReservation> retVal = new List<UserReservation>();
            Location pickup, dropoff;
            foreach (CarReservation reservation in reservations)
            {
                pickup = await dbContext.Locations.FindAsync(reservation.PickupLocationId);
                if (pickup == null)
                {
                    return BadRequest();
                }

                dropoff = await dbContext.Locations.FindAsync(reservation.DropoffLocationId);
                if (dropoff == null)
                {
                    return BadRequest();
                }

                retVal.Add(new UserReservation
                {
                    Car = reservation.Car.Brand + " " + reservation.Car.Model,
                    PickupLocation = pickup.Country + ", " + pickup.City,
                    PickupAddress = pickup.Adress,
                    PickupDate = reservation.PickupDate,
                    PickupTime = reservation.PickupTime,
                    DropoffLocation = dropoff.Country + ", " + dropoff.City,
                    DropoffAddress = dropoff.Adress,
                    DropoffDate = reservation.DropoffDate,
                    DropoffTime = reservation.DropoffTime,
                    Price = reservation.Price
                });
            }

            return Ok(retVal);
        }

        class UserReservation
        {
            public string Car { get; set; }
            public string PickupLocation { get; set; }
            public string PickupAddress { get; set; }
            public string PickupDate { get; set; }
            public string PickupTime { get; set; }
            public string DropoffLocation { get; set; }
            public string DropoffAddress { get; set; }
            public string DropoffDate { get; set; }
            public string DropoffTime { get; set; }
            public int Price { get; set; }
        }

        private int ResLengthCalculator(string fromS, string toS)
        {
            DateTime from = String2Date(fromS);
            DateTime to = String2Date(toS);

            TimeSpan span = to - from;

            return span.Days;
        }

        private DateTime String2Date(string date)
        {
            int year, month, day;

            string[] dateString = date.Split('-');

            Int32.TryParse(dateString[0], out year);
            Int32.TryParse(dateString[1], out month);
            Int32.TryParse(dateString[2], out day);

            return new DateTime(year, month, day);
        }
    }
}
