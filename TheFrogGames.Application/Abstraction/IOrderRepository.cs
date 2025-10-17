using TheFrogGames.Domain.Entities;
namespace TheFrogGames.Application.Abstraction
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        List<Order> GetOrdersByUser(int userId, bool trackChanges = false);
        Order? GetOrderWithItems(int orderId, bool trackChanges = false);

    }

}
