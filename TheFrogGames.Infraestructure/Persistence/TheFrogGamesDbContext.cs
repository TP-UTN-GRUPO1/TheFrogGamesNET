using Microsoft.EntityFrameworkCore;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infraestructure.Persistence;

public class TheFrogGamesDbContext : DbContext

{
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Game { get; set; }

    public TheFrogGamesDbContext(DbContextOptions<TheFrogGamesDbContext> options) : base(options)
    {

    }
}
