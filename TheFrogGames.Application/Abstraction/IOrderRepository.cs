using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Abstraction
{
    public interface IOrderRepository
    {
        Order? GetById(int id);
        void Add(Order order);
        List<Order> GetAll();
        void Update(Order order);
        void Delete(Order order);

    }

}
