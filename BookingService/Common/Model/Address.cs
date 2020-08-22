using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Location { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
    }
}
