using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class FlightInvitation
    {
        public int Id { get; set; }
        public User From { get; set; }
        public User To { get; set; }
        public Reservation Reservation { get; set; }
    }
}
