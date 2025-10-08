using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Abstraction;

public interface IUserRepository : IBaseRepository<User>
{
    bool UpdateUserStatus(User user);
    bool ParcialUpdateUser(User user);
}
