using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class MovieService {

        private static readonly HttpClient httpClient = new HttpClient();
        
        
        private JsonSerializerOptions deserialise = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        };

        private JsonSerializerOptions serialise = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public MovieService() {
             
        }

        public async Task<bool> AddMovie(Movie movie) {
            Console.WriteLine("adding movie /server method");

            StringContent content = new StringContent(
                CustomJsonSerialization.Serialise(movie),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("", content);
            if (response.StatusCode != HttpStatusCode.Created) {
                Console.WriteLine("Server error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            Console.WriteLine("success");
            return true;
        }
    }
}