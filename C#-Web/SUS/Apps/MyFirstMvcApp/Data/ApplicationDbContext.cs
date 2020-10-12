using Microsoft.EntityFrameworkCore;

namespace BattleCards.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<UserCard> UserCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BattleCards;Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>(entity =>
            {
                entity.HasKey(x => new { x.CardId, x.UserId });
            });
        }
    }
}
