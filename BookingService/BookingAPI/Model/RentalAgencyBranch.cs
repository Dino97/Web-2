using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class RentalAgencyBranch
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RentalAgencyId")]
        public int AgencyId { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public DateTime WorkTimeFrom { get; set; }
        [Required]
        public DateTime WorkTimeTo { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<Car> Cars { get; set; }
        public bool NearAirpot { get; set; }
    }
}
