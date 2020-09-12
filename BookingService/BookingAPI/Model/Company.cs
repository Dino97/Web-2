using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string AdminUserName { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Logo { get; set; }
    }
}
