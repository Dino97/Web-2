using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public class SocialLoginModel
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string id { get; set; }
        //public string photoUrl { get; set; }
        //public string authToken { get; set; }
        //public string authorizationCode { get; set; }
    }
}
