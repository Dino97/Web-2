using System;
using System.Collections.Generic;

namespace Common.Model
{
    public class Flight
    {
        public DateTime TakeOff { get; set; }
        public DateTime Landing { get; set; }
        public float FlightDuration { get; set; }
        public float FlightDistance { get; set; }
        public List<City> Layovers { get; set; }
        public float TicketPrice { get; set; }
        public int Rating { get; set; }
    }
}
