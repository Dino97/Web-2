using Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Flight Flight { get; set; }

        [Required]
        public User User { get; set; }

        public string Seats { get; set; }

        public bool Confirmed { get; set; }
    }
}
