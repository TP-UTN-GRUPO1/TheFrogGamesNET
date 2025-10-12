using TheFrogGames.Contracts.User.Request;

namespace TheFrogGames.Application.Abstraction.ExternalServices;

public interface IAuthService
{
    string Login(LoginUserRequest request);
}
