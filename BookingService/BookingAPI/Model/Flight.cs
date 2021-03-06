﻿using System;
using System.Collections.Generic;

namespace BookingAPI.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Landing { get; set; }
        public string Locations { get; set; }
        public float FlightDuration { get; set; }
        public float FlightDistance { get; set; }
        public float TicketPrice { get; set; }
        public int Rating { get; set; }
        public Airline Airline { get; set; }

        public string Seats { get; set; }
    }
}
