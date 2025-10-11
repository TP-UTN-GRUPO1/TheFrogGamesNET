using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(TheFrogGamesDbContext context) : base(context)
        {
        }
        


    }
    

    }
