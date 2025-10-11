using TheFrogGames.Application.Contracts.Genre.Request;
using TheFrogGames.Contracts.Genre.Response;

namespace TheFrogGames.Application.Service
{
    public interface IGenreService
    {
        List<GenreResponse> GetGenres();
        GenreResponse CreateGenre(CreateGenreRequest request);
        GenreResponse UpdateGenre(UpdateGenreRequest request);
        bool DeleteGenre(int id);
    }
}
