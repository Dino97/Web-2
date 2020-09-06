using System;

namespace BookingAPI.Model
{
    public class FriendRequest
    {
        public enum EStatus { Sent, Accepted }

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Sent { get; set; }
        public EStatus Status { get; set; }
    }
}
