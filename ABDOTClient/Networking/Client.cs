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
using ABDOTClient.Networking.Requests.Interfaces;

namespace ABDOTClient.Networking {
    public class Client {
        private IUserRequest userRequest;
        private IMovieRequest movieRequest;
        private IPlayRequest playRequest;
        private IProgramRequest programRequest;
        private ITicketRequest ticketRequest;
        private IEmployeeRequest employeeRequest;
        private IHallRequest hallRequest;
        private IBranchRequest branchRequest;

        public Client() {
            userRequest = new UserRequest();
            movieRequest = new MovieRequest();
            playRequest = new PlayRequest();
            ticketRequest = new TicketRequest();
            employeeRequest = new EmployeeRequest();
            hallRequest = new HallRequest();
            branchRequest = new BranchRequest();
            Branch branch = new Branch() {
                Id = 1,
                City = "chujowo2",
                Street = "pica",
                Postcode = "694202137",
                Country = "jebane"
            };

            Movie movie = new Movie() {
                Id = 9,
                Title = "Whatever 2",
                Description = "Chuj w dupe",
                Genre = "Hardcore Erotica",
                Director = "Adam Sandler",
                Language = "Arabic",
                SubtitleLanguage = "asda",
                Year = 1992,
                LengthInMinutes = 132,
                PosterSrc = "pornhub.com"
            };

            Employee employee = new Employee() {
                FirstName = "john",
                LastName = "jarajman",
                Email = "test@gmail.com",
                Password = "chujjjjjj",
                Street = "hujowa",
                City = "jebanemiasto",
                Country = "wakacje",
                Birthday = new DateTime(2020, 12, 12),
                Branch = branch,
                Id = 5,
                Postcode = "2020",
                Role = 1,
                CPR = "21376969"
            };
            
            

            
        }


        //please make the methods in order of the classes
        public async Task<Branch> CreateBranch(Branch branch) {
            try {
                return await branchRequest.CreateBranch(branch);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Branch> EditBranch(Branch branch) {
            try {
                return await branchRequest.EditBranch(branch);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteBranch(long branchId) {
            try {
                return await branchRequest.DeleteBranch(branchId);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<Branch> GetBranch(int branchId) {
            try {
                return await branchRequest.GetBranch(branchId);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IList<Branch>> GetAllBranches() {
            try {
                return await branchRequest.GetAllBranches();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<User> RegisterUser(User user) {
            try {
                return await userRequest.RegisterUser(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
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

        public async Task<User> EditUser(User user) {
            try {
                return await userRequest.EditUser(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
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

        public async Task<IList<User>> GetAllUsers() {
            try {
                return await userRequest.GetAllUsers();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task<Movie> AddMovie(Movie movie) {
            try {
                return await movieRequest.CreateMovie(movie);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Movie> EditMovie(Movie movie) {
            return await movieRequest.EditMovie(movie);
        }

        public async Task<bool> DeleteMovie(int movieId) {
            try {
                return await movieRequest.DeleteMovie(movieId);
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

        public async Task<IList<Movie>> GetAllMovies() {
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

        public async Task<Play> GetPlay(int id) {
            try {
                return await playRequest.Get(id);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Play>> GetAllPlays() {
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

        public async Task<Ticket> AddTicket(Ticket ticket) {
            try {
                return await ticketRequest.CreateTicketAsync(ticket);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Ticket> EditTicket(Ticket ticket) {
            try {
                return await ticketRequest.EditTicketAsync(ticket);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteTicket(int movieId) {
            try {
                return await ticketRequest.DeleteTicketAsync(movieId);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Ticket> GetTicket(int ticketId) {
            try {
                return await ticketRequest.GetTicketAsync(ticketId);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Ticket>> GetAllTickets() {
            try {
                return await ticketRequest.GetAllTicketsAsync();
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

        public async Task<bool> DeleteHall(int hallId) {
            try {
                return await hallRequest.DeleteHall(hallId);
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

        public async Task<IList<Hall>> GetAllHalls() {
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
                return await employeeRequest.CreateEmployee(employee) == null;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> EditEmployee(Employee employee) {
            try {
                return await employeeRequest.EditEmployee(employee) == null;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int employeeId) {
            try {
                return await employeeRequest.DeleteEmployee(employeeId);
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

        public async Task<IList<Employee>> GetAllEmployees() {
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