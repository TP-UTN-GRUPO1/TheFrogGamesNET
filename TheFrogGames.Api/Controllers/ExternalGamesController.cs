﻿using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Application.Abstraction.ExternalServices;
using TheFrogGames.Application.Service;
using TheFrogGames.Contracts.Game.Response;

namespace TheFrogGames.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ExternalGamesController : ControllerBase
    {
        private readonly IExternalGameService _externalGameService;
        private readonly IGameService _gameService;

        public ExternalGamesController(
               IExternalGameService externalGameService,
               IGameService gameService)
        {
            _externalGameService = externalGameService;
            _gameService = gameService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResponse>>> GetGamesFromFirebase(CancellationToken cancellationToken)
        {
            var games = await _externalGameService.GetGames(cancellationToken);
            return Ok(games);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportGamesToDatabase(CancellationToken cancellationToken)
        {
            var externalGames = await _externalGameService.GetGames(cancellationToken);

            if (!externalGames.Any())
                return BadRequest("No se encontraron juegos en Firebase.");

            await _gameService.AddGamesAsync(externalGames, cancellationToken);
            return Ok(new { message = "Juegos importados correctamente." });
        }
    }
}

       
