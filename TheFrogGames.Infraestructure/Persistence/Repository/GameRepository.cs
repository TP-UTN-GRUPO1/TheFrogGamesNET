using Microsoft.EntityFrameworkCore;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entities;

namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private readonly TheFrogGamesDbContext _context;

        public GameRepository(TheFrogGamesDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddAsync(Game game)
        {
            await _context.Games.AddAsync(game);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
