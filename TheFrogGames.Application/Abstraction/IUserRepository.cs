using TheFrogGames.Contracts.User.Request;
using TheFrogGames.Domain.Entities;

namespace TheFrogGames.Application.Abstraction;

public interface IUserRepository : IBaseRepository<User>
{
    bool UpdateUserStatus(User user);
    bool ParcialUpdateUser(User user);
    User GetUserByEmailAndPassword(LoginUserRequest request);

}
