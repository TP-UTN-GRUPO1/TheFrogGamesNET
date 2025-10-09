using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheFrogGames.Application.Abstraction;

namespace TheFrogGames.Infraestructure.Persistence.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly TheFrogGamesDbContext _context;
    private readonly DbSet<T> _dbSet;
    protected BaseRepository(TheFrogGamesDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual List<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public virtual T? GetById(int id)
    {
        return _dbSet.Find(id);
    }
    public virtual bool Create(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();

        return true;
    }
    public virtual bool Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();

        return true;
    }

    public virtual bool Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();

        return true;
    }
    public virtual List<T> GetByCriteria(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression).ToList();
    }

}
