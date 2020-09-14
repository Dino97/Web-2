using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookingAPI.Model;
using System;

namespace BookingAPI
{
    public class BookingDbContext : IdentityDbContext
    {
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<RentalAgency> RentalAgencies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<FlightInvitation> FlightInvitations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RentalAgencyBranch> RentalAgencyBranches { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Date> CarDates { get; set; }
        public DbSet<Airline> Airlines { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FriendRequest>().HasKey(fr => new { fr.From, fr.To });

            builder.Entity<RentalAgency>().HasIndex(c => c.Name).IsUnique();

            #region Airports
            builder.Entity<Airport>().HasData(new Airport()
            {
                Name = "Nikola Tesla",
                City = "Belgrade",
                Country = "Serbia"
            });
            builder.Entity<Airport>().HasData(new Airport()
            {
                Name = "Narita",
                City = "Tokyo",
                Country = "Japan"
            });
            #endregion
        }
    }
}
