using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookingAPI.Model;

namespace BookingAPI
{
    public class BookingDbContext : IdentityDbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) :
            base (options)
        {}

        public DbSet<User> AppUsers { get; set; }

        public DbSet<Friend> UserFriends { get; set; }
    }
}
