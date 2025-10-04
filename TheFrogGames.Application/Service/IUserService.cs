using Contract.User.Request;
using TheFrogGames.Contracts.User.Request;
using TheFrogGames.Contracts.User.Response;

namespace TheFrogGames.Application.Service;

public interface IUserService
{
    UserResponse GetUserById(int id);
    bool CreateUser(CreateUserRequest user);
    List<UserResponse> GetAllUsers();
    bool UpdateUserStatus(UserStatusRequest request);
}