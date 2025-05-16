using Microsoft.EntityFrameworkCore;
using VendorConnect.Models;

namespace VendorConnect.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
