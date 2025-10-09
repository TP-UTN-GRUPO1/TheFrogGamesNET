using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFrogGames.Contracts.Game.Request;
using TheFrogGames.Contracts.Game.Response;

namespace TheFrogGames.Application.Service
{
    public interface IGameService
    {
        List<GameResponse> GetAll();
        bool Create(CreateGameRequest request);

    }
}
