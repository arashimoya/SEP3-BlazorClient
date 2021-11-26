using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ABDOTClient.Data;
using ABDOTClient.Model;
using ABDOTClient.Networking.Requests;

namespace ABDOTClient.Networking {
    public class Client {
        private IUserRequest userRequest;
        private IMovieRequest movieRequest;
        private IPlayRequest playRequest;
        private IProgramRequest programRequest;
        private ISeatRequest seatRequest;
        

        public Client() {
            userRequest = new UserRequestImpl();
            movieRequest = new MovieRequestImpl();
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

        public async Task<bool> EditUser(User user) {
            try {
                return await userRequest.EditUser(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteUser(User user) {
            try {
                return await userRequest.DeleteUser(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<User> GetUser(int id) {
            try {
                return await userRequest.GetUser(id);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<User>> GetAllUsers() {
            try {
                return await userRequest.GetAllUsers();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
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

        public async Task<bool> EditMovie(Movie movie) {
            return await movieRequest.EditMovie(movie);
        }

        public async Task<bool> DeleteMovie(Movie movie) {
            try {
                return await movieRequest.DeleteMovie(movie);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Movie> GetMovie(int id) {
            try {
                return await movieRequest.GetMovie(id);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Movie>> GetAllMovies() {
            try {
                return await movieRequest.GetAllMovies();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> AddPlay(Play play) {
            try {
                return await playRequest.CreatePlay(play);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> EditPlay(Play play) {
            try {
                return await playRequest.EditPlay(play);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeletePlay(Play play) {
            try {
                return await playRequest.DeletePlay(play);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Play> Get(int id) {
            try {
                return await playRequest.Get(id);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Play>> GetAllPlays() {
            try {
                return await playRequest.GetAllPlays();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> AddProgram(Program program) {
            try {
                return await programRequest.CreateProgram(program);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> EditProgram(Program program) {
            try {
                return await programRequest.EditProgram(program);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteProgram(Program program) {
            try {
                return await programRequest.DeleteProgram(program);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Program> GetProgram(int id) {
            try {
                return await programRequest.GetProgram(id);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Program>> GetAllPrograms() {
            try {
                return await programRequest.GetAllPrograms();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> AddSeat(Seat seat) {
            try {
                return await seatRequest.CreateSeat(seat);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> EditSeat(Seat seat) {
            try {
                return await seatRequest.EditSeat(seat);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteSeat(Seat seat) {
            try {
                return await seatRequest.DeleteSeat(seat);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Seat> GetSeat(int id) {
            try {
                return await seatRequest.GetSeat(id);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Seat>> GetAllSeats() {
            try {
                return await seatRequest.GetAllSeats();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

       
    }
}