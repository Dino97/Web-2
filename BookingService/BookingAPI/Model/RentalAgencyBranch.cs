using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class RentalAgencyBranch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public int WorksFrom { get; set; }
        [Required]
        public int WorksTo { get; set; }
        public string ContactNumber { get; set; }
        ICollection<Car> Cars { get; set; }
        public bool NearAirpot { get; set; }
    }
}
