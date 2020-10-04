using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            string location = AppDomain.CurrentDomain.BaseDirectory + model.Brand.ToLower() + model.Model.ToLower();
            
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

                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
