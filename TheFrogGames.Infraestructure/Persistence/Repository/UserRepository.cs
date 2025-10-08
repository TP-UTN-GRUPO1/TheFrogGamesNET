using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infraestructure.Persistence.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly TheFrogGamesDbContext _context;
    public UserRepository(TheFrogGamesDbContext context) : base(context)
    {
        _context = context;
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
