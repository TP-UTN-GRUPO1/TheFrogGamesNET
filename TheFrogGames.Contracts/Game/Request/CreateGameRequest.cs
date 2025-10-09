
using System.ComponentModel.DataAnnotations;

namespace TheFrogGames.Contracts.Game.Request
{
    public class CreateGameRequest
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Title { get; set; }
        [Required(ErrorMessage = "El desarrollador es requerido")]
        public string Developer { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]

        public decimal Price { get; set; }
        public int Rating { get; set; }
        public Boolean IsActivated { get; set; }

        public List<int> GenreIds { get; set; } = new();
        public List<int> PlatformIds { get; set; } = new();

    }
}
