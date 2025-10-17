using TheFrogGames.Domain.Entities;

namespace TheFrogGames.Application.Abstraction
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<Game?> GetByIdAsync(int id);
        Task AddAsync(Game game);
        Task SaveChangesAsync();
    }
}
