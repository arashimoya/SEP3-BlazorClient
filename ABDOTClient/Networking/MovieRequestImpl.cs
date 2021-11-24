using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class MovieRequestImpl : IMovieRequest {

        private static readonly HttpClient httpClient = new HttpClient();
        
        public MovieRequestImpl() {
             
        }

        public async Task<bool> CreateMovie(Movie movie) {
            throw new NotImplementedException();
        }

        public Task<bool> EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetAllMovies()
        {
            throw new NotImplementedException();
        }
    }
}