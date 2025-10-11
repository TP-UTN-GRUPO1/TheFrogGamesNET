using Microsoft.EntityFrameworkCore;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infrastructure.Persistence
{
    public class TheFrogGamesDbContext : DbContext
    {
        public TheFrogGamesDbContext(DbContextOptions<TheFrogGamesDbContext> options)
            : base(options)
        {
        }
        public TheFrogGamesDbContext()
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Game)
                .WithMany()
                .HasForeignKey(oi => oi.GameId);
        }
    }
}
