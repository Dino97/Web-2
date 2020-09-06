using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public enum UserType
    {
        User,   // neko bolje ime mozda
        AirlineAdmin,
        CarRentalServiceAdmin,
        Admin
    }

    public class User : IdentityUser
    {
        //[Key]
        //public string Username { get; set; }
        //public string Password { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }
        //public UserType UserType { get; set; }
    }
}
