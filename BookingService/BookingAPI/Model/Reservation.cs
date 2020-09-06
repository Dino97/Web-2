using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public User User { get; set; }
    }
}
