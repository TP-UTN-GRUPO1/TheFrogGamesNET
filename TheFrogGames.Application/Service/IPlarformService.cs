using TheFrogGames.Application.Contracts.Platform.Request;
using TheFrogGames.Contracts.Platform.Response;

namespace TheFrogGames.Application.Service
{
    public interface IPlatformService
    {
        List<PlatformResponse> GetPlatform();
        PlatformResponse CreatePlatform(CreatePlatformRequest request);
        PlatformResponse UpdatePlatform(UpdatePlatformRequest request);
        bool DeletePlatform(int id);
    }
}
