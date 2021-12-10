using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IMovieService
    {
        
        Task<Movie> AddMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(Movie movie);
        Task<bool> RemoveMovieAsync(int movieId);
        Task<Movie> GetMovieAsync(int id);
        Task<IList<Movie>> GetAllAsync();
        
    }
}