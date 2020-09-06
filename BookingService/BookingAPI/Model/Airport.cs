using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Model
{
    public class Airport
    {
        [Key]
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
