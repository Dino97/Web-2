using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Model
{
    public enum Status { ACCEPTED, DECLINED, ON_HOLD }

    public class Friend
    {
        [Key]
        public int Id { get; set; }                 // id "Friend"-a u tabeli
        public int FriendId { get; set; }             // id korisnika koji je prijatelj

        public Status RequestStatus { get; set; }
    }
}
