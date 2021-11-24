using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class UserService {
        private static readonly HttpClient httpClient = new HttpClient();

        private JsonSerializerOptions deserialise = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        };

        private JsonSerializerOptions serialise = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public UserService() {
            
        }


        public async Task<bool> RegisterUser(User user) {
            StringContent content = new StringContent(
                CustomJsonSerialization.Serialise(user),
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await httpClient.PostAsync("", content);
            if (!response.IsSuccessStatusCode) {
                Console.WriteLine("Error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            Console.WriteLine($"User {user} registered successfully");
            return true;
        }

        public async Task<User> Login(User user) {
            Console.WriteLine("Validating user /server");
            StringContent content = new StringContent(
                CustomJsonSerialization.Serialise(user),
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage response = await httpClient.PostAsync("", content);
            if (!response.IsSuccessStatusCode) {
                Console.WriteLine("Server error");
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }

            
            string userAsJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine(userAsJson + "from api");
            return (User) CustomJsonSerialization.Deserialise(userAsJson);
        }
    }
}