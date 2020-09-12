using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class RentalAgency : Company
    {
        public ICollection<RentalAgencyBranch> Branches { get; set; }
    }
}
