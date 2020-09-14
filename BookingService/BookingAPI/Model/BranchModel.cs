using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class BranchModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string NearAirport { get; set; }
        public string WorksFrom { get; set; }
        public string WorksTo { get; set; }
        public string ContactNumber { get; set; }
    }
}
