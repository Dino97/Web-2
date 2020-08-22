using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Model
{
    public enum UserType
    {
        User,   // neko bolje ime mozda
        AirlineAdmin,
        CarRentalServiceAdmin,
        Admin
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<User> Friends { get; set; }
        public UserType UserType { get; set; }
    }
}
