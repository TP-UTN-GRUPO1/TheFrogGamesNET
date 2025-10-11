using Contract.User.Request;
using TheFrogGames.Contracts.User.Request;
using TheFrogGames.Contracts.User.Response;

namespace TheFrogGames.Application.Services
{
    public interface IUserService
    {
        List<UserResponse> GetAllUsers();
        UserResponse? GetUserById(int id);
        UserResponse? CreateUser(CreateUserRequest request);
        UserResponse? UpdateUser(int id, UpdateUserRequest request);
        bool DeleteUser(int id);
    }
}
