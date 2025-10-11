using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(TheFrogGamesDbContext context) : base(context)
        {
        }



    }


}