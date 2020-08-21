using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Airline
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public List<City> Destinations { get; set; }
        public List<Flight> Flights { get; set; }
        // Spisak karata sa popustima za brzu rezervaciju
        // Konfiguracija segmenta i mesta u avionima
        // Cenovnik i informacije o prtljagu
    }
}
