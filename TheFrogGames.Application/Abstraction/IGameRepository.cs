using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Abstraction
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Game GetGameById(int id);
    }
}
