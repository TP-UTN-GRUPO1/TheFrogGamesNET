﻿
using System.Text.Json.Serialization;
using TheFrogGames.Contracts.Genre.Response;
using TheFrogGames.Contracts.Platform.Response;
using TheFrogGames.Domain.Entities;

namespace TheFrogGames.Contracts.Game.Response
{
    public class GameResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Boolean Available { get; set; }
        public float Rating { get; set; }
        public int Sold { get; set; }
        [JsonPropertyName("platform")]
        public List<string> Platforms { get; set; } = new();

        [JsonPropertyName("genre")]
        public List<string> Genres { get; set; } = new();
        
    }
}
