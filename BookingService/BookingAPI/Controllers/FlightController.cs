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
            string destinations = "";
            for (int i = 0; i < newFlight.Destinations.Length; i++)
            {
                destinations += newFlight.Destinations[i];

                if (i < newFlight.Destinations.Length - 1)
                    destinations += ",";
            }

            Flight flight = new Flight()
            {
                Departure = newFlight.Departure,
                Landing = newFlight.Landing.AddHours(newFlight.FlightDuration),
                FlightDistance = newFlight.FlightDistance,
                FlightDuration = newFlight.FlightDuration,
                TicketPrice = newFlight.TicketPrice,
                Locations = destinations,
                Seats = new string('0', 36),
                Rating = 0
            };

            dbContext.Flights.Add(flight);
            dbContext.SaveChanges();
        }

        [HttpPost]
        [Route("Search")]
        public IEnumerable<Flight> Search(FlightSearchParams searchParams)
        {
            List<Flight> flights = dbContext.Flights.Where(f =>
                f.Departure.Date == searchParams.Departure.Date &&
                f.Landing.Date == searchParams.Landing.Date
            ).ToList();

            // Filter by location
            for (int i = flights.Count - 1; i >= 0; i--)
            {
                Airport[] locations = ParseLocations(flights[i].Locations);

                // Filter by origin
                if (locations[0].Name.Equals(searchParams.From) == false)
                {
                    flights.RemoveAt(i);
                    continue;
                }

                // Filter by destination
                {
                    bool foundDestination = false;
                    for (int j = 1; j < locations.Length; j++)
                    {
                        if (locations[j].Name.Equals(searchParams.To))
                        {
                            foundDestination = true;
                            break;
                        }
                    }

                    if (!foundDestination)
                    {
                        flights.RemoveAt(i);
                        continue;
                    }
                }
            }

            // Filter by passenger number
            for (int i = flights.Count - 1; i >= 0; i--)
            {
                if (flights[i].Seats.Count(c => c == '0') < searchParams.Passengers)
                    flights.RemoveAt(i);
            }

            return flights;
        }

        [HttpGet]
        [Route("GetAirports")]
        public IEnumerable<Airport> GetAirports()
        {
            return dbContext.Airports;
        }

        private Airport[] ParseLocations(string locations)
        {
            string[] ids = locations.Split(',');
            Airport[] airports = new Airport[ids.Length];

            for (int i = 0; i < ids.Length; i++)
                airports[i] = dbContext.Airports.Find(ids[i]);

            return airports;
        }
    }

    public class FlightSearchParams
    {
        public enum ETripType { RoundTrip, OneWay, MultiCity }

        public string From { get; set; }
        public string To { get; set; }
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
