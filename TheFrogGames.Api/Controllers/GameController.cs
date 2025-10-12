using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Contracts.Game.Request;
using TheFrogGames.Application.Service;
using TheFrogGames.Contracts.Game.Response;
using TheFrogGames.Application.Abstraction;

using System.Threading.Tasks;

namespace TheFrogGames.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public ActionResult<List<GameResponse>> GetAll()
        {
            var listGame = _gameService.GetAll();
            if (!listGame.Any())
            {
                return NotFound();
            }
            return Ok(listGame);
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateGameRequest game)
        {
            var isCreated = _gameService.Create(game);

            if (!isCreated)
            {
                return Conflict("Error al crear el producto");
            }

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game.Id);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

    }
}