using System.Collections.Generic;
using TheFrogGames.Application.Contracts.Responses;
using TheFrogGames.Contracts.Order.Request;

public interface IOrderService
{
    OrderResponse? CreateOrder(CreateOrderRequest request);
    OrderResponse? GetOrderById(int id);
    List<OrderResponse> GetOrdersByUser(int userId);
    bool DeleteOrder(int id);
   
}
