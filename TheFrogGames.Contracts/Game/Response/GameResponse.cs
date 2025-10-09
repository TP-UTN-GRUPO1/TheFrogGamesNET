using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFrogGames.Contracts.Game.Response
{
    public class GameResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public Boolean IsActivated { get; set; }

        public List<string> Genres { get; set; } = new();
        public List<string> Platforms{ get; set; } = new();
    }
}
