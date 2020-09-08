using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class AdminModel : UserModel
    {
        public string CompanyType { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
    }
}
