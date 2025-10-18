﻿
namespace TheFrogGames.Contracts.Game.Request
{
    public class CreateGameRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Boolean Available { get; set; }
        public float Rating { get; set; }
        public int Sold { get; set; }

        public List<string> Platforms { get; set; } = new();
        public List<string> Genres { get; set; } = new();
    }
}
