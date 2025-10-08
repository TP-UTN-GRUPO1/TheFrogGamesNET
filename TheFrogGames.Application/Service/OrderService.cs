using TheFrogGames.Application.Abstraction;
using TheFrogGames.Contracts.Order.Request;
using TheFrogGames.Contracts.Order.Response;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Service

{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGameRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IGameRepository productRepository,
            IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public OrderDetailResponse GetOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                return null;
            }

            var user = _userRepository.GetById(order.UserId);
            string username = user != null ? user.Name : "Desconocido";

            var dto = new OrderDetailResponse
            {
                OrderId = order.Id,
                CreatedAt = order.OrderDate,
                Username = username,
                Items = order.Items.Select(oi => new OrderItemResponse
                {
                    GameId = oi.GameId,
                    Title = oi.Game.Title,
                    Quantity = oi.Quantity,
                    Price = oi.UnitPrice
                }).ToList()
            };

            return dto;
        }

        public int CreateOrder(CreateOrderRequest request)
        {
            var user = _userRepository.GetById(request.UserId);
            if (user == null)
            {
                throw new Exception("Usuario no válido");
            }
            if (request.Items == null || !request.Items.Any())
            {
                throw new Exception("Debe tener al menos un ítem");
            }

            var order = new Order
            {
                UserId = request.UserId,
                OrderDate = DateTime.Now
            };

            foreach (var itemReq in request.Items)
            {
                var product = _productRepository.GetGameById(itemReq.ProductId);
                if (product == null)
                {
                    throw new Exception($"Producto con Id {itemReq.ProductId} no encontrado");
                }
                if (itemReq.Quantity <= 0)
                {
                    throw new Exception("La cantidad debe ser mayor que cero");
                }

                var orderItem = new OrderItem
                {
                    GameId = product.Id,
                    Quantity = itemReq.Quantity,
                    UnitPrice = product.Price
                };
                order.Items.Add(orderItem);
            }
            _orderRepository.Add(order);

            return order.Id;
        }

        public List<OrderListResponse> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            var list = new List<OrderListResponse>();

            foreach (var order in orders)
            {
                var user = _userRepository.GetById(order.UserId);
                string username = user != null ? user.Name : "Desconocido";

                decimal total = order.Items.Sum(oi => oi.Quantity * oi.UnitPrice);

                var dto = new OrderListResponse
                {
                    OrderId = order.Id,
                    CreatedAt = order.OrderDate,
                    Username = username,
                    Total = total
                };
                list.Add(dto);
            }

            return list;
        }

        public void UpdateOrder(int orderId, CreateOrderRequest request)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new Exception("Orden no encontrada");
            }
            order.Items.Clear();

            foreach (var itemReq in request.Items)
            {
                var product = _productRepository.GetGameById(itemReq.ProductId);
                if (product == null)
                {
                    throw new Exception($"Producto {itemReq.ProductId} no existe");
                }
                if (itemReq.Quantity <= 0)
                {
                    throw new Exception("Cantidad inválida");
                }

                var oi = new OrderItem
                {
                    GameId = product.Id,
                    Quantity = itemReq.Quantity,
                    UnitPrice = product.Price
                };
                order.Items.Add(oi);
            }

            _orderRepository.Update(order);
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new Exception("Orden no encontrada");
            }

            _orderRepository.Delete(order);
        }
    }



}