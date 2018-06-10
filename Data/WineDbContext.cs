using gm18119.Models;
using Microsoft.EntityFrameworkCore;

namespace gm18119.Data
{
    // WineDbContext class holds the representation of the state of the DB in the application
    public class WineDbContext : DbContext
    {
        public WineDbContext(DbContextOptions options)
            : base(options)
        {}

        // defining what kind of data is held in the DB
        public DbSet<Wine> Wines { get; set; }
    }
}