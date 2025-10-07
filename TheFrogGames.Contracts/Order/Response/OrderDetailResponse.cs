namespace TheFrogGames.Contracts.Order.Response
{
    public class OrderDetailResponse
    {
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? Username { get; set; }

        public List<OrderItemResponse> Items { get; set; }

        public decimal Total => Items.Sum(i => i.Subtotal);
    }
}
