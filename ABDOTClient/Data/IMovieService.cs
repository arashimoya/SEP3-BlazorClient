using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IMovieService
    {
        
        Task<bool> AddMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> RemoveMovieAsync(Movie movie);
        Task<Movie> GetAsync(int id);
        Task<IList<Movie>> GetAllAsync();
        
    }
}