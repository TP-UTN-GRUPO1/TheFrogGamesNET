using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Application.Contracts.Game.Request;
using TheFrogGames.Application.Service;
using TheFrogGames.Contracts.Game.Response;

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
            var list = _gameService.GetGame();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateGameRequest request)
        {
            try
            {
                var newGame = _gameService.CreateGame(request);
                return CreatedAtAction(
                    nameof(GetAll),
                    new { id = newGame.Id },
                    newGame);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateGameRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedGame = _gameService.UpdateGame(request);
                return Ok(updatedGame);
            }
            catch (Exception ex) when (ex.Message.Contains("no encontrado"))
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID del juego debe ser positivo.");
            }
            bool success = _gameService.DeleteGame(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al intentar eliminar el juego.");
            }
        }
    }
}