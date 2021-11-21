using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IMovieService
    {
        Task<IList<Movie>> GetAllAsync();
        Task<bool> AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task RemoveMovieAsync(int movieId);
        Task<Movie> GetAsync(int id);
        
    }
}