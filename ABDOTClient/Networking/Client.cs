using System;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Networking.Requests;

namespace ABDOTClient.Networking {
    public class Client {
        private IUserRequest userRequest;
        private IMovieRequest movieRequest;
        private IOperatorRequest operatorRequest;
        private IPersonRequest personRequest;
        private IPlayRequest playRequest;
        private IProgramRequest programRequest;
        private ISeatRequest seatRequest;

        public Client() {
            userRequest = new UserRequestImpl();
            movieRequest = new MovieRequestImpl();
            operatorRequest = new OperatorRequest();
            personRequest = new PersonRequest();
            playRequest = new PlayRequest();
            programRequest = new ProgramRequest();
            seatRequest = new SeatRequest();
        }
        
        


        //please make the methods in order of the classes
        public async Task<bool> RegisterUser(User user) {
            try {
                return await userRequest.RegisterUser(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<User> LoginUser(User user) {
            try {
                return await userRequest.Login(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> AddMovie(Movie movie) {
            try {
                return await movieRequest.CreateMovie(movie);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}