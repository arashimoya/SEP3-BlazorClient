using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking
{
    public interface IMovieRequest
    {

        Task<Movie> CreateMovie(Movie movie);

        Task<Movie> EditMovie(Movie movie);

        Task<bool> DeleteMovie(int movieId);

        Task<Movie> GetMovie(int movieId);

        Task<IList<Movie>> GetAllMovies();

    }
}