﻿namespace TheFrogGames.Application.Contracts.Responses
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

