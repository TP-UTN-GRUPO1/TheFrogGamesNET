﻿using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using TheFrogGames.Application.Abstraction.ExternalServices;
using TheFrogGames.Contracts.Game.Response;
using TheFrogGames.Infrastructure.Options;

namespace TheFrogGames.Infrastructure.ExternalServices
{
    public class GamesFromFirebaseService : IExternalGameService
    {
        private readonly HttpClient _httpClient;

        public GamesFromFirebaseService(HttpClient httpClient, IOptions<GamesApiOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
                 _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        
        public async Task<IEnumerable<GameResponse>> GetGames(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<GameResponse>>(
                    "dataGames.json", cancellationToken);

                return response ?? Enumerable.Empty<GameResponse>();
            }
            catch 
            {
                Console.WriteLine("Error al obtener los juegos");
                throw;
            }
        }
    }
}
