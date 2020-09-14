using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingAPI.Model
{
    public class Airline
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdminUsername { get; set; }
        public Image Logo { get; set; }
        //public List<City> Destinations { get; set; }
        //public List<Flight> Flights { get; set; }
        // Spisak karata sa popustima za brzu rezervaciju
        // Konfiguracija segmenta i mesta u avionima
        // Cenovnik i informacije o prtljagu
    }
}
