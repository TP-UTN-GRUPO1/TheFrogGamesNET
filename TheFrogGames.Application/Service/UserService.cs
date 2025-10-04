using Contract.User.Request;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Contracts.User.Request;
using TheFrogGames.Contracts.User.Response;
using TheFrogGames.Domain.Entity;

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
            Email = user.Email,
            Date = user.Date,
            IsActive = user.IsActive
        };
    }
    public bool CreateUser(CreateUserRequest user)
    {
        var newUser = new User
        {
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            Date =  user.Date,
            Password = user.Password
        };
        return _userRepository.CreateUser(newUser);
    }

    public List<UserResponse> GetAllUsers()
    {
       
        var userList = _userRepository
            .GetAllUsers()
            .Where(u => u.IsActive)
            .Select(u => new UserResponse
            {
                CompleteName = $"{u.Name} {u.LastName}",
                Email = u.Email,
                Date =u.Date,
                IsActive = u.IsActive

            }).ToList();
        return userList;
    }

    public bool UpdateUserStatus(UserStatusRequest request)
    {
        var user = _userRepository.GetUserById(request.Id);

        if (user == null)
        {
            return false;
        }

        user.IsActive = !user.IsActive;

        return _userRepository.UpdateUserStatus(user);
    }
    
}
