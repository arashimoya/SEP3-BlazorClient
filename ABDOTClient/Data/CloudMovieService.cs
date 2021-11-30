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


        public async Task<bool> AddMovieAsync(Movie movie)
        {
            return await ClientFactory.GetClient().AddMovie(movie);
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            return await ClientFactory.GetClient().EditMovie(movie);
        }

        public async Task<bool> RemoveMovieAsync(Movie movie)
        {
            return await ClientFactory.GetClient().DeleteMovie(movie);
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await ClientFactory.GetClient().GetMovie(id);
        }

        public async Task<IList<Movie>> GetAllAsync()
        {
            return await ClientFactory.GetClient().GetAllMovies();
        }
    }
}
    


