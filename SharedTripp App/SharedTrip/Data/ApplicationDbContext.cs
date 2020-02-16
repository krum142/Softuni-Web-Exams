using SharedTrip.Models;

namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> User { get; set; }

        public DbSet<Trip> Trip { get; set; }

        public DbSet<UserTrip> UserTrip { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>().HasKey(x => new {x.TripId, x.UserId});
        }
    }
}
