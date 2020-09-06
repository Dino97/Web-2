using System;
using System.Collections.Generic;

namespace BookingAPI.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public List<Airport> Layovers { get; set; } // From i To mogu biti na pocetku i kraju liste
        public DateTime Departure { get; set; }
        public DateTime Landing { get; set; }
        public float FlightDuration { get; set; }
        public float FlightDistance { get; set; }
        public float TicketPrice { get; set; }
        public int Rating { get; set; }
    }
}
