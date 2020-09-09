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

        [HttpGet]
        [Route("GetFlight")]
        public Flight GetFlight(int id)
        {
            return dbContext.Flights.Find(id);
        }

        [HttpPost]
        //[Authorize(Roles = "AirlineAdmin")]
        [Route("NewFlight")]
        public void NewFlight(NewFlightParams newFlight)
        {
            List<Airport> destinations = new List<Airport>();
            foreach (string destination in newFlight.Destinations)
            {
                Airport a = dbContext.Airports.Find(destination);

                if (a != null)
                    destinations.Add(a);
            }

            Flight flight = new Flight()
            {
                Departure = newFlight.Departure,
                Landing = newFlight.Landing,
                FlightDistance = newFlight.FlightDistance,
                FlightDuration = newFlight.FlightDuration,
                TicketPrice = newFlight.TicketPrice,
                Locations = destinations.ToList(),
                Rating = 0
            };

            dbContext.Flights.Add(flight);
            dbContext.SaveChanges();
        }

        [HttpPost]
        [Route("Search")]
        public IEnumerable<Flight> Search(FlightSearchParams searchParams)
        {
            /*IEnumerable<Flight> flights = dbContext.Flights.Where(f =>
                f.Locations[0].Name.Equals(searchParams.Origin) || 
                f.Locations[0].City.Equals(searchParams.Origin) || 
                f.Locations[0].Country.Equals(searchParams.Origin)
            );*/

            IEnumerable<Flight> flights = dbContext.Flights.Include(f => f.Locations);

            return flights;
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

    public class NewFlightParams
    {
        public DateTime Departure { get; set; }
        public DateTime Landing { get; set; }
        public float FlightDistance { get; set; }
        public float FlightDuration { get; set; }
        public float TicketPrice { get; set; }
        public string[] Destinations { get; set; }
    }
}
