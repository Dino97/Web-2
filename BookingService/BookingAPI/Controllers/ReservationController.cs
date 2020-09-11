using System;
using System.Collections.Generic;
using System.Linq;
using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public class NewReservationParams
        {
            public int FlightId { get; set; }
            public string[] Passengers { get; set; }
            public int[] Seats { get; set; }
            public string[] Passports { get; set; }
        }

        private BookingDbContext dbContext;
        private UserManager<User> userManager;


        public ReservationController(BookingDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserReservations")]
        public IEnumerable<Reservation> GetUserReservations()
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;

            return dbContext.Reservations.Include(r => r.Flight).Where(r => r.User.UserName.Equals(username) && r.Confirmed == true);
        }

        [HttpGet]
        [Authorize]
        [Route("GetFlightInvitations")]
        public IEnumerable<FlightInvitation> GetFlightInvitations()
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;

            return dbContext.FlightInvitations.Include(i => i.From)
                                              .Include(i => i.To)
                                              .Where(r => r.To.UserName.Equals(username));
        }

        [HttpPost]
        [Authorize]
        [Route("AcceptFlightInvite")]
        public void AcceptFlightInvite(int id)
        {
            FlightInvitation invite = dbContext.FlightInvitations.Include(fi => fi.Reservation).FirstOrDefault(fi => fi.Id == id);
            invite.Reservation.Confirmed = true;

            dbContext.Entry(invite).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        [HttpPost]
        [Authorize]
        [Route("DeclineFlightInvite")]
        public void DeclineFlightInvite(int id)
        {
            FlightInvitation invite = dbContext.FlightInvitations.Include(fi => fi.Reservation).ThenInclude(r => r.Flight).FirstOrDefault(fi => fi.Id == id);
            FreeReservedSeats(invite.Reservation);

            dbContext.Entry(invite).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        [HttpPost]
        [Authorize]
        [Route("CreateReservation")]
        public void CreateReservation(NewReservationParams data)
        {
            Flight flight = dbContext.Flights.Find(data.FlightId);

            string username = User.Claims.First(c => c.Type == "UserName").Value;
            User user = userManager.FindByNameAsync(username).Result;

            if (flight != null)
            {
                Reservation personalReservation = new Reservation() { Flight = flight, User = user, Seats = "", Confirmed = true };

                for (int i = 0; i < data.Passengers.Length; i++)
                {
                    string passenger = data.Passengers[i];

                    if (passenger.Equals("Self") || passenger.Equals("UU"))
                    {
                        personalReservation.Seats += data.Seats[i] + ",";
                    }
                    else
                    {
                        User friend = userManager.FindByNameAsync(passenger).Result;

                        Reservation friendReservation = new Reservation()
                        {
                            Flight = flight,
                            User = friend,
                            Seats = data.Seats[i].ToString(),
                            Confirmed = false
                        };

                        dbContext.Reservations.Add(friendReservation);

                        // Add invitation
                        FlightInvitation invitation = new FlightInvitation()
                        {
                            From = user,
                            To = friend,
                            Reservation = friendReservation
                        };

                        dbContext.FlightInvitations.Add(invitation);
                    }

                    // Reserve seat on flight
                    char[] seatsString = flight.Seats.ToCharArray();
                    seatsString[data.Seats[i] - 1] = '1';
                    flight.Seats = new string(seatsString);
                }

                // Remove last comma
                string seats = personalReservation.Seats;
                personalReservation.Seats = seats.Remove(seats.Length - 1);

                dbContext.Reservations.Add(personalReservation);
                dbContext.SaveChanges();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("CancelReservation")]
        public void CancelReservation(int id)
        {
            Reservation reservation = dbContext.Reservations.Include(r => r.Flight).SingleOrDefault(r => r.Id == id);

            if (reservation != null && reservation.Flight.Departure > DateTime.Now.AddHours(3))
            {
                FreeReservedSeats(reservation);
                dbContext.Entry(reservation).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        private void FreeReservedSeats(Reservation reservation)
        {
            char[] seats = reservation.Flight.Seats.ToCharArray();

            foreach (string seatStr in reservation.Seats.Split(','))
            {
                int seatIndex = int.Parse(seatStr) - 1;
                seats[seatIndex] = '0';
            }

            reservation.Flight.Seats = new string(seats);
        }
    }
}
