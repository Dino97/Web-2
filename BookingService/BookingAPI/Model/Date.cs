using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Date
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CarId")]
        public int CarId { get; set; }
        [Required]
        public DateTime DateReserved { get; set; }
    }
}
