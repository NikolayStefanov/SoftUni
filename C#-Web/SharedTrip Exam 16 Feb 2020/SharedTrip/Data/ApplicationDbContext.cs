using Microsoft.EntityFrameworkCore;
using SharedTrip.Data.Models;

namespace SharedTrip.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SharedTrip;Integrated Security=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>(entity =>
            {
                entity.HasKey(x => new { x.TripId, x.UserId });
            });
        }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }
    }
}
