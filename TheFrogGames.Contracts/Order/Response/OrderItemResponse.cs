namespace TheFrogGames.Contracts.Order.Response
{
    public class OrderItemResponse
    {
        public int GameId { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => Price * Quantity;
    }
}
