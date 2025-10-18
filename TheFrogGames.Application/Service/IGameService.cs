using TheFrogGames.Contracts.Game.Request;
using TheFrogGames.Contracts.Game.Response;

namespace TheFrogGames.Application.Abstraction;

public interface IGameService
{
    List<GameResponse> GetAll();
    List<GameResponse> Search(string? name, int? categoriaId, decimal? pMin, decimal? pMax);
    List<GameResponse> GetByValue(decimal valor);
    GameResponse? GetGameById(int id);
    bool Create(CreateGameRequest request);
    bool Update(int id, CreateGameRequest request);
    bool UpdateKeyMetadata(int id, UpdateKeyMetadataGameRequest producto);
    bool Delete(int id);
    bool softDeleteGame(int id ,ParcialUpdateGameRequest request);
    Task AddGamesAsync(IEnumerable<GameResponse> games, CancellationToken cancellationToken = default);
}
