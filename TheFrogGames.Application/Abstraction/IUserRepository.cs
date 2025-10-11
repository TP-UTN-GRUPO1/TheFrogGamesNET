using TheFrogGames.Domain;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Abstraction
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetByEmail(string email, bool trackChanges = false);
    }
}
