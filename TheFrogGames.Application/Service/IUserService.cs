using TheFrogGames.Contracts.User.Response;

namespace TheFrogGames.Application.Service;

public interface IUserService
{
    UserResponse GetUserById(int id);
}