using Contract.User.Request;
using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Application.Service;
using TheFrogGames.Contracts.Game.Request;

namespace TheFrogGames.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameServices;
        public GamesController(IGameService gamesServices)
        {
            _gameServices = gamesServices;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateGameRequest game)
        {
            var isCreated = _gameServices.Create(game);

            if (!isCreated)
            {
                return Conflict("Error al crear el producto");
            }

            return Ok("Usuario creado");
        }
    }
}
