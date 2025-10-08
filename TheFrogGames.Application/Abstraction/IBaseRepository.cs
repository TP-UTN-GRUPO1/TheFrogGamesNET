namespace TheFrogGames.Application.Abstraction;

public interface IBaseRepository<T> where T : class
{
    List<T> GetAll();
    T? GetById(int id);
    bool Create(T entity);
    bool Update(T entity);
    bool Delete(T entity);

}
