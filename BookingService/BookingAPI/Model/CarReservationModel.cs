using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class CarReservationModel
    {
        public int CarId { get; set; }
        public string Car { get; set; }
        public int PickupLocationId { get; set; }
        public int DropoffLocationId { get; set; }
        public string FromDate { get; set; }
        public string FromTime { get; set; }
        public string ToDate { get; set; }
        public string ToTime { get; set; }
        public int Price { get; set; }
    }
}
