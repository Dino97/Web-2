using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class CarReservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Car Car { get; set; }
        public int PickupLocationId { get; set; }
        public int DropoffLocationId { get; set; }
        public string PickupDate { get; set; }
        public string PickupTime { get; set; }
        public string DropoffDate { get; set; }
        public string DropoffTime { get; set; }
        public int Price { get; set; }
    }
}
