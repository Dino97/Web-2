using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookingAPI.Model;

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

        public BookingDbContext(DbContextOptions<BookingDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FriendRequest>().HasKey(fr => new { fr.From, fr.To });

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
