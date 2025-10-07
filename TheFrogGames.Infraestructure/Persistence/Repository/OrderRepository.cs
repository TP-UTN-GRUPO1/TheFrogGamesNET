using Microsoft.EntityFrameworkCore;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Infraestructure.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TheFrogGamesDbContext _db;

        public OrderRepository(TheFrogGamesDbContext db)
        {
            _db = db;
        }

        public Order? GetById(int id)
        {
            return _db.Orders
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Game)
                .FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _db.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ToList();
        }
        public void Update(Order order)
        {
            _db.Orders.Update(order);
            _db.SaveChanges();
        }
        public void Delete(Order order)
        {
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }
    }

}
