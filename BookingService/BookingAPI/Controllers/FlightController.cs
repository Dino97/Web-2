using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Model;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public class FlightSearchParams
        {
            public enum ETripType { RoundTrip, OneWay, MultiCity }
            public enum EClass { Economy, Business, First }

            public string Origin { get; set; }
            public string Destination { get; set; }
            public DateTime Departure { get; set; }
            public DateTime Landing { get; set; }
            public ETripType TripType { get; set; }
            public int Passengers { get; set; }
            public EClass Class { get; set; }
            public int Luggage { get; set; }
        }

        [HttpGet]
        public IEnumerable<Flight> Search(/*[FromBody] FlightSearchParams searchParams*/)
        {
            return new Flight[] { new Flight()
            {
                Departure = new DateTime(2020, 4, 20),
                Landing = new DateTime(2020, 4, 21),
                FlightDistance = 204,
                FlightDuration = 2,
                Layovers = null,
                Rating = 4,
                TicketPrice = 199
            }};
        }
    }
}
