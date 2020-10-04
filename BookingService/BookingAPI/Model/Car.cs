using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RentalAgencyBranchId")]
        public int RentalAgencyBranchId { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public float PricePerDay { get; set; }
        public string Image { get; set; }
        public bool Airconditioner { get; set; }
        public bool Automatic { get; set; }
        public int NumberOfPassengers { get; set; }
        public string Drive { get; set; }
        public ICollection<Date> Reserved { get; set; }

    }
}
