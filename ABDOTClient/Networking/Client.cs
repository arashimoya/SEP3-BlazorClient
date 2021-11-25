using System;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class Client {
        private IUserRequest IuserRequest;
        private IMovieRequest ImovieRequest;

        public Client() {
            IuserRequest = new UserRequestImpl();
            ImovieRequest = new MovieRequestImpl();
        }

        
        //please make the methods in order of the classes
        public async Task<bool> RegisterUser(User user) {
            try {
                return await IuserRequest.RegisterUser(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<User> LoginUser(User user) {
            try {
                return await IuserRequest.Login(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> AddMovie(Movie movie) {
            try {
                return await ImovieRequest.CreateMovie(movie);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}