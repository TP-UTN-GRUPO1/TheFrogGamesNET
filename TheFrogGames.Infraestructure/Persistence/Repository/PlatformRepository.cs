using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entities;

namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(TheFrogGamesDbContext context) : base(context)
        {
        }



    }


}