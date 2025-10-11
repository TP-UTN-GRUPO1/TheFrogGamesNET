using Contract.User.Request;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Contracts.User.Request;
using TheFrogGames.Contracts.User.Response;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<UserResponse> GetAllUsers()
        {

            var userList = _userRepo
                .GetAll()
                .Where(u => u.IsActive)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    LastName = u.LastName,
                    Email = u.Email,
                    Date = u.Date,
                    IsActive = u.IsActive

                }).ToList();
            return userList;
        }

        public UserResponse? GetUserById(int id)
        {
            var user = _userRepo.GetById(id, trackChanges: false);
            if (user == null) return null;
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                IsActive = user.IsActive
            };
        }

        public UserResponse? CreateUser(CreateUserRequest request)
        {
            var exist = _userRepo.GetByEmail(request.Email, trackChanges: false);
            if (exist != null)
            {
                return null;
            }

            var user = new User
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };

            bool created = _userRepo.Create(user);
            if (!created) return null;

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
            };
        }

        public UserResponse? UpdateUser(int id,UpdateUserRequest request)
        {
            var existing = _userRepo.GetById(request.Id, trackChanges: true);
            if (existing == null) return null;

            if (!string.IsNullOrEmpty(request.Name))
                existing.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Email))
                existing.Email = request.Email;
            if (!string.IsNullOrEmpty(request.Password))
                existing.Password = request.Password;

            bool updated = _userRepo.Update(existing);
            if (!updated) return null;

            return new UserResponse
            {
                Id = existing.Id,
                Name = existing.Name,
                Email = existing.Email,
            };
        }

        public bool DeleteUser(int id)
        {
            var existing = _userRepo.GetById(id, trackChanges: false);
            if (existing == null) return false;
            return _userRepo.Delete(existing);
        }

    }

}