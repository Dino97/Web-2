using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class RentalAgency
    {
        [Key]
        public int Id { get; set; }
        public ICollection<RentalAgencyBranch> Branches { get; set; }
        [Required]
        public string AdminUserName { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Logo { get; set; }
    }
}
