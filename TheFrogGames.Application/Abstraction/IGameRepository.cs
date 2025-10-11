using TheFrogGames.Domain.Entity;
using TheFrogGames.Application.Abstraction;

namespace TheFrogGames.Application.Abstraction
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Game GetGameById(int id);
    }
}
