using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TheFrogGames.Infrastructure.Persistence;
using TheFrogGames.Application.Abstraction;


namespace TheFrogGames.Infrastructure.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly TheFrogGamesDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(TheFrogGamesDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll(bool trackChanges = false)
        {
            if (!trackChanges)
                return _dbSet.AsNoTracking().ToList();
            return _dbSet.ToList();
        }

        public T? GetById(object id, bool trackChanges = false)
        {
            var entity = _dbSet.Find(id);
            if (entity != null && !trackChanges)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            if (!trackChanges)
                return _dbSet.Where(expression).AsNoTracking();
            return _dbSet.Where(expression);
        }

        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            return Save() > 0;
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            return Save() > 0;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Save() > 0;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
