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

        public async Task<Movie> AddMovieAsync(Movie movie) {
            movie.PosterSrc = "css/images/default_poster.jpg";
            return await ClientFactory.GetClient().AddMovie(movie);
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            movie.PosterSrc = "css/images/default_poster.jpg";
            return await ClientFactory.GetClient().EditMovie(movie);
        }

        public async Task<bool> RemoveMovieAsync(int movieId)
        {
            return await ClientFactory.GetClient().DeleteMovie(movieId);
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            return await ClientFactory.GetClient().GetMovie(id);
        }

        public async Task<IList<Movie>> GetAllAsync()
        {
            return await ClientFactory.GetClient().GetAllMovies();
        }
    }
}
    


