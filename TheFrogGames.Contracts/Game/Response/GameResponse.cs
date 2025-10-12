
using TheFrogGames.Domain.Entity;

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
        public int Rating { get; set; }
        public int Sold { get; set; }

        public PlatformID? Platform { get; set; }
    }
}
