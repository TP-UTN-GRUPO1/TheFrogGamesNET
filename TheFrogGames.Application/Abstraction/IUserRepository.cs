using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Abstraction;

public interface IUserRepository
{
    User GetUserById(int id);
}
