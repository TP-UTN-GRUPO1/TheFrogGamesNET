using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entities;

namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(TheFrogGamesDbContext context) : base(context)
        {
        }
        


    }
    

    }
