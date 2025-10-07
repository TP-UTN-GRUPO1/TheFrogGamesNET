﻿using System.ComponentModel.DataAnnotations;

namespace TheFrogGames.Contracts.Order.Request
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public List<CreateOrderItemRequest>? Items { get; set; }


    }
}
