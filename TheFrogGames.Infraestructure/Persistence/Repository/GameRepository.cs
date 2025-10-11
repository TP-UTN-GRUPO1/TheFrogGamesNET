using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class GameRepository : BaseRepository<Game>,IGameRepository
    {

        public GameRepository(TheFrogGamesDbContext context) : base(context)
        {
        }

        public Game GetGameById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
