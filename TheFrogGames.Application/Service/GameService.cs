
using Contract.User.Request;
using TheFrogGames.Application.Abstraction;
using TheFrogGames.Contracts.Game.Request;
using TheFrogGames.Contracts.Game.Response;
using TheFrogGames.Domain.Entity;


namespace TheFrogGames.Application.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository productoRepository)
        {
            _gameRepository = productoRepository;
            
        }
        public List<GameResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Create(CreateGameRequest game)
        {
            var newGame = new Game
            {
                Title = game.Title,
                Developer = game.Developer,
                ImageUrl = game.ImageUrl,
               
            };
            return _gameRepository.Create(newGame);
        }
    }
}
