using Microsoft.EntityFrameworkCore;
using Common.Model;

namespace BookingAPI
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) :
            base (options)
        {}

        public DbSet<User> Users { get; set; }
    }
}
