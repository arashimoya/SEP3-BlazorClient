using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class CloudMovieService : IMovieService
    {
        public Task<IList<Movie>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task AddMovieAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateMovieAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveMovieAsync(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}