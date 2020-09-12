using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public float PricePerDay { get; set; }
        public string Image { get; set; }
        public bool Convertable { get; set; }
        public int NumberOfPassenger { get; set; }
        public string Drive { get; set; }
        
    }
}
