using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking
{
    public interface IMovieRequest
    {

        Task<bool> CreateMovie(Movie movie);

        Task<bool> EditMovie(Movie movie);

        Task<bool> DeleteMovie(Movie movie);

        Task<Movie> GetMovie(int id);

        Task<List<Movie>> GetAllMovies();

    }
}