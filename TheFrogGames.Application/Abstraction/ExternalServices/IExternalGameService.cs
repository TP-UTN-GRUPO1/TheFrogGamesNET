using TheFrogGames.Contracts.Game.Response;

namespace TheFrogGames.Application.Abstraction.ExternalServices
{
    public interface IExternalGameService
    {
        Task<IEnumerable<GameResponse>> GetGames(CancellationToken cancellationToken = default);
    }
}
