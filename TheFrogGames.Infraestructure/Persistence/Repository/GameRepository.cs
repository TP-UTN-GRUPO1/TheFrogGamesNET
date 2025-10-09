using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infraestructure.Persistence.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        private readonly TheFrogGamesDbContext _context;

        public GameRepository(TheFrogGamesDbContext context) : base(context)
        {
            _context = context;
        }
    
        public Game GetGameById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
