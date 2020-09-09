using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Company
    {
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LogoId { get; set; }
    }
}
