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
    public UserResponse GetById(int id)
    {
        var user = _userRepository.GetById(id);

        var completeName = $"{user.Name} {user.LastName}";

        return new UserResponse
        {
            CompleteName = completeName,
            Email = user.Email,
            Date = user.Date,
            IsActive = user.IsActive
        };
    }
    public bool Create(CreateUserRequest user)
    {
        var newUser = new User
        {
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            Date = user.Date,
            Password = user.Password
        };
        return _userRepository.Create(newUser);
    }

    public List<UserResponse> GetAll()
    {

        var userList = _userRepository
            .GetAll()
            .Where(u => u.IsActive)
            .Select(u => new UserResponse
            {
                Id = u.Id.ToString(),
                CompleteName = $"{u.Name} {u.LastName}",
                Email = u.Email,
                Date = u.Date,
                IsActive = u.IsActive

            }).ToList();
        return userList;
    }

    public bool UpdateUserStatus(ParcialUpdateUserRequest request)
    {
        var user = _userRepository.GetById(request.Id);

        if (user == null)
        {
            return false;
        }

        user.IsActive = !user.IsActive;

        return _userRepository.UpdateUserStatus(user);
    }

    public bool ParcialUpdateUser(int id, ParcialUpdateUserRequest user)
    {
        var ExistingUser = _userRepository.GetById(id);

        if (ExistingUser == null)
        {
            return false;
        }
        ExistingUser.Name = user.Name ?? ExistingUser.Name;
        ExistingUser.LastName = user.LastName ?? ExistingUser.LastName;

        return _userRepository.ParcialUpdateUser(ExistingUser);
    }
    public bool Update(int id, UpdateUserRequest user)
    {
        var ExistingUser = _userRepository.GetById(id);
        if (ExistingUser == null)
        {
            return false;
        }
        ExistingUser.Name = user.Name;
        ExistingUser.LastName = user.LastName;
        ExistingUser.Email = user.Email;
        return _userRepository.Update(ExistingUser);
    }
    public bool Delete(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            return false;
        }

        return _userRepository.Delete(user);
    }

}
