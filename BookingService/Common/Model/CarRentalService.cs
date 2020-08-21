using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class CarRentalService
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        // Cenovnik usluga
        public List<Car> Cars { get; set; }
        public List<Address> Branches { get; set; }
    }
}
