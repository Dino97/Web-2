using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Company
    {
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Logo { get; set; }
    }
}
