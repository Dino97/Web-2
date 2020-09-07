using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class AdminModel : UserModel
    {
        public string AdminType { get; set; }
    }
}
