using Microsoft.EntityFrameworkCore;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Contracts.User.Request;
using TheFrogGames.Domain.Entity;
using TheFrogGames.Infrastructure.Persistence;
using TheFrogGames.Infrastructure.Persistence.Repository;

namespace TheFrogGames.Infraestructure.Persistence.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly TheFrogGamesDbContext _context;
    public UserRepository(TheFrogGamesDbContext context) : base(context)
    {
        _context = context;
    }
    public User? GetUserByEmailAndPassword(LoginUserRequest request)
    {
        return _context.Users
            .Include(x => x.Role)
            .FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
    }
    public bool UpdateUserStatus(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return true;
    }

    public bool ParcialUpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return true;
    }
}
