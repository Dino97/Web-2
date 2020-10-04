using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class CarModel
    {
        public int BranchId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int PricePerDay { get; set; }
        public string Image { get; set; }
        public string Drive { get; set; }
        public int NumberOfPassengers { get; set; }
        public string Automatic { get; set; }
        public string Airconditioner { get; set; }
    }
}
