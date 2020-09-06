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

        public BookingDbContext(DbContextOptions<BookingDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Reservation>().HasData(new Reservation() {})
            //builder.Entity<FriendRequest>().HasKey(fr => new { fr.From, fr.To });
        }
    }
}
