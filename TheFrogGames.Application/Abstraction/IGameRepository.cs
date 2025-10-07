using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Abstraction
{
    public interface IGameRepository
    {
        Game GetGameById(int id);
    }
}
