using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private BookingDbContext dbContext;



        public FlightController(BookingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Authorize(Roles = "AirlineAdmin")]
        [Route("NewFlight")]
        public void NewFlight()
        {
            Flight flight = new Flight()
            {
                Departure = new DateTime(),
                Landing = new DateTime(),
                FlightDistance = 0,
                FlightDuration = 0,
                Rating = 0,
                Locations = { },
                TicketPrice = 0
            };

            dbContext.Flights.Add(flight);
            dbContext.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Flight> Search(FlightSearchParams searchParams)
        {
            /*dbContext.Flights.Where(f => 
                f.
            )*/

            DateTime departure = searchParams.Departure.Date;

            return null;
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserReservations")]
        public IEnumerable<Reservation> GetUserReservations()
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;

            return dbContext.Reservations.Where(r => r.User.UserName.Equals(username));
        }

        [HttpPost]
        [Route("CancelReservation")]
        public void CancelReservation(int id)
        {
            Reservation reservation = dbContext.Reservations.Find(id);

            if (reservation == null && reservation.Flight.Departure > DateTime.Now.AddHours(3))
            {
                dbContext.Entry(reservation).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetAirports")]
        public IEnumerable<Airport> GetAirports()
        {
            return dbContext.Airports;
        }
    }

    public class FlightSearchParams
    {
        public enum ETripType { RoundTrip, OneWay, MultiCity }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Landing { get; set; }
        public ETripType TripType { get; set; }
        public int Passengers { get; set; }
        public int Luggage { get; set; }

        //public enum EClass { Economy, Business, First }
        //public EClass Class { get; set; }
    }
}
