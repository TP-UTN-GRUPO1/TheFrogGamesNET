
namespace TheFrogGames.Contracts.Order.Response
{
    public class OrderListResponse
    {
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Username { get; set; }
        public decimal Total { get; set; }
    }
}
