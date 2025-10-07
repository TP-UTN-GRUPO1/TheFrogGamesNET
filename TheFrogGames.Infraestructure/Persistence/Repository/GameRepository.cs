using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infraestructure.Persistence.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly TheFrogGamesDbContext _db;

        public GameRepository(TheFrogGamesDbContext db)
        {
            _db = db;
        }

        public Game GetGameById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
