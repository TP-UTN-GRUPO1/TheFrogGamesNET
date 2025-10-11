using Microsoft.EntityFrameworkCore;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TheFrogGamesDbContext context) : base(context)
        {
        }

        public User? GetByEmail(string email, bool trackChanges = false)
        {
            var query = _context.Set<User>().Where(u => u.Email == email);
            if (!trackChanges)
                query = query.AsNoTracking();
            return query.FirstOrDefault();
        }
    }
}