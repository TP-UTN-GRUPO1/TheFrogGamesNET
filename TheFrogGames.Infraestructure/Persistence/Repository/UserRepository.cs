using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infraestructure.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly TheFrogGamesDbContext _context;
    public UserRepository(TheFrogGamesDbContext context)
    {
        _context = context;
    }
    public User GetUserById(int id)
    {
        return _context.Users.FirstOrDefault(c => c.Id == id);
    }
    public bool CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return true;
    }
    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public bool UpdateUserStatus(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return true;
    }
}
