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
    public class Client
    {
        private IUserRequest userRequest;
        private IMovieRequest movieRequest;
        private IPlayRequest playRequest;
        private IProgramRequest programRequest;
        private ITicketRequest ticketRequest;
        private IEmployeeRequest employeeRequest;
        private IHallRequest hallRequest;

        public Client()
        {
            userRequest = new UserRequest();
            movieRequest = new MovieRequest();
            playRequest = new PlayRequest();
            programRequest = new ProgramRequest();
            ticketRequest = new TicketRequest();
            employeeRequest = new EmployeeRequest();
            hallRequest = new HallRequest();

            
            //***********
            //TESTS
            //***********
            
            // Hall testHall = new Hall(1);
            // Hall testHall1 = new Hall(2);
            // Hall testHall2 = new Hall(3);
            // testHall.PrintArray();
            // testHall1.PrintArray();
            // testHall2.PrintArray();

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
        
        public async Task<bool> AddTicket(Ticket ticket) {
            try {
                return await ticketRequest.Create(ticket);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> EditTicket(Ticket ticket) {
            try {
                return await ticketRequest.Edit(ticket);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteTicket(Ticket ticket) {
            try {
                return await ticketRequest.Delete(ticket);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Ticket> GetTicket(int ticketId) {
            try {
                return await ticketRequest.GetTicket(ticketId);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Ticket>> GetAllTickets() {
            try {
                return await ticketRequest.GetAllTicktets();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> AddHall(Hall hall) {
            try {
                return await hallRequest.CreateHall(hall);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> EditHall(Hall hall) {
            try {
                return await hallRequest.EditHall(hall);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteHall(Hall hall) {
            try {
                return await hallRequest.DeleteHall(hall);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Hall> GetHall(int hallId) {
            try {
                return await hallRequest.GetHall(hallId);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Hall>> GetAllHalls() {
            try {
                return await hallRequest.GetAllHalls();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<bool> AddEmployee(Employee employee) {
            try {
                return await employeeRequest.CreateEmployee(employee);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> EditEmployee(Employee employee) {
            try {
                return await employeeRequest.EditEmployee(employee);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(Employee employee) {
            try {
                return await employeeRequest.DeleteEmployee(employee);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Employee> GetEmployee(int employeeId) {
            try {
                return await employeeRequest.GetEmployee(employeeId);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Employee>> GetAllEmployees() {
            try {
                return await employeeRequest.GetAllEmployees();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
    }
}