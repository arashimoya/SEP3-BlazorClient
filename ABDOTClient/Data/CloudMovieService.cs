using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;
using ABDOTClient.Networking;
using ABDOTClient.Persistence;

namespace ABDOTClient.Data
{
    public class CloudMovieService : IMovieService
    {
        private IList<Movie> movies;
        private ServerContext ServerContext;
        private Client client;

        public CloudMovieService()
        {
            ServerContext = new ServerContext();
            client = new Client();
        }

        public async Task<IList<Movie>> GetAllAsync()
        {
            return movies;
        }

        public async Task<bool> AddMovieAsync(Movie movie)
        {
            return await ClientFactory.GetClient().AddMovie(movie);
        }

        public Task UpdateMovieAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveMovieAsync(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> GetAsync(int id)
        {
            Movie toReturn = movies.FirstOrDefault(m => m.Id == id);
            return toReturn;
        }

        private void Seed()
        {
        }
    }
}
    


