using TheFrogGames.Application.Abstraction;
using TheFrogGames.Contracts.User.Response;

namespace TheFrogGames.Application.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public UserResponse GetUserById(int id)
    {
        var user = _userRepository.GetUserById(id);

        var completeName = $"{user.Name} {user.LastName}";

        return new UserResponse
        {
            CompleteName = completeName,
            Email = user.Email
        };
    }
}
