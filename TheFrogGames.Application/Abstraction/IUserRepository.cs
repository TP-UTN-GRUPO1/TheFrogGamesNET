using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Abstraction;

public interface IUserRepository
{
    User GetUserById(int id);
    bool CreateUser (User user);
    List<User> GetAllUsers();
    bool UpdateUserStatus(User user);
}
