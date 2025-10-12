using TheFrogGames.Application.Abstraction;
using TheFrogGames.Contracts.Game.Request;
using TheFrogGames.Contracts.Game.Response;
using TheFrogGames.Domain.Entity;

namespace TheFrogGames.Application.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepo;

        public GameService(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        public List<GameResponse> GetAll()
        {
            var games = _gameRepo.GetAll();

            return games.Select(g => new GameResponse
            {
                Id = g.Id,
                Title = g.Title,
                Price = g.Price,
                Developer = g.Developer,
                ImageUrl = g.ImageUrl,
                Rating = g.Rating,
                Available = g.Available,
                Sold = g.Sold
            }).ToList();
        }

        public GameResponse? GetGameById(int id)
        {
            var game = _gameRepo.GetById(id);
            if (game == null) return null;

            return new GameResponse
            {
                Id = game.Id,
                Title = game.Title,
                Price = game.Price,
                Developer = game.Developer,
                ImageUrl = game.ImageUrl,
                Rating = game.Rating,
                Available = game.Available,
                Sold = game.Sold
            };
        }

        public List<GameResponse> Search(string? name, int? categoriaId, decimal? pMin, decimal? pMax)
        {
            var games = _gameRepo.GetAll().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                games = games.Where(g => g.Title.Contains(name, StringComparison.OrdinalIgnoreCase));

        

            if (pMin.HasValue)
                games = games.Where(g => g.Price >= pMin.Value);

            if (pMax.HasValue)
                games = games.Where(g => g.Price <= pMax.Value);

            return games.Select(g => new GameResponse
            {
                Id = g.Id,
                Title = g.Title,
                Price = g.Price,
                Developer = g.Developer,
                ImageUrl = g.ImageUrl,
                Rating = g.Rating,
                Available = g.Available,
                Sold = g.Sold
            }).ToList();
        }

        public List<GameResponse> GetByValue(decimal valor)
        {
            var games = _gameRepo.GetAll().Where(g => g.Price == valor);

            return games.Select(g => new GameResponse
            {
                Id = g.Id,
                Title = g.Title,
                Price = g.Price,
                Developer = g.Developer,
                ImageUrl = g.ImageUrl,
                Rating = g.Rating,
                Available = g.Available,
                Sold = g.Sold
            }).ToList();
        }

        public int GetTotalGames()
        {
            return _gameRepo.GetAll().Count();
        }

        public bool Create(CreateGameRequest request)
        {
            var game = new Game
            {
                Title = request.Title,
                Price = request.Price,
                Developer = request.Developer,
                ImageUrl = request.ImageUrl,
                Rating = request.Rating,
                Available = request.Available,
                Sold = request.Sold
            };

            bool success = _gameRepo.Create(game);

            if (!success)
                throw new ApplicationException("Error al crear el juego en la base de datos.");

            return true;
        }

        public bool Update(int id, CreateGameRequest request)
        {
            var existingGame = _gameRepo.GetById(id, trackChanges: true);
            if (existingGame == null)
                throw new Exception($"Juego con ID {id} no encontrado.");

            existingGame.Title = request.Title;
            existingGame.Price = request.Price;
            existingGame.Developer = request.Developer;
            existingGame.ImageUrl = request.ImageUrl;
            existingGame.Rating = request.Rating;
            existingGame.Available = request.Available;
            existingGame.Sold = request.Sold;

            bool success = _gameRepo.Update(existingGame);

            if (!success)
                throw new ApplicationException("Error al actualizar el juego en la base de datos.");

            return true;
        }

        public bool UpdateKeyMetadata(int id, UpdateKeyMetadataGameRequest producto)
        {
            var existingGame = _gameRepo.GetById(id, trackChanges: true);
            if (existingGame == null)
                throw new Exception($"Juego con ID {id} no encontrado.");

         

            bool success = _gameRepo.Update(existingGame);

            if (!success)
                throw new ApplicationException("Error al actualizar la metadata del juego.");

            return true;
        }

        public bool Delete(int id)
        {
            var gameToDelete = _gameRepo.GetById(id);
            if (gameToDelete == null)
                return true; // nada que borrar

            return _gameRepo.Delete(gameToDelete);
        }
    }
}
