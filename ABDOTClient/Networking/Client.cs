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
    public class Client
    {
        private IUserRequest userRequest;
        private IMovieRequest movieRequest;
        private IPlayRequest playRequest;
        private IProgramRequest programRequest;
        private ITicketRequest ticketRequest;
        private IEmployeeRequest employeeRequest;
        private IHallRequest hallRequest;
        private IBranchRequest branchRequest;

        public Client()
        {
            userRequest = new UserRequest();
            movieRequest = new MovieRequest();
            playRequest = new PlayRequest();
            ticketRequest = new TicketRequest();
            employeeRequest = new EmployeeRequest();
            hallRequest = new HallRequest();
            branchRequest = new BranchRequest();
            
            
            //***********
            //TEST OBJECTS
            //***********
            
            // Branch branch = new Branch()
            // {
            //     Id = 1,
            //     City = "chujowo2",
            //     Street = "pica",
            //     Postcode = "694202137",
            //     Country = "jebane"
            // };
            //
            // Hall hall = new Hall(1)
            // {
            //     Id = 1,
            //     Branch = branch,
            //     Programme = null
            // };
            // Movie movie = new Movie()
            // {
            //     Id = 1,
            //     Title =  "Whatever 2",
            //     Description = "Chuj w dupe",
            //     Genre = "Hardcore Erotica",
            //     Director = "Adam Sandler",
            //     Language = "Arabic",
            //     SubtitleLanguage = "asda",
            //     Year = 1992,
            //     LengthInMinutes = 132,
            //     PosterSrc = "pornhub.com"
            // };
            // Play play = new Play()
            // {
            //     Id = 1,
            //     Date = new DateTime(2021 - 12 - 21),
            //     Hall = hall,
            //     Movie = movie,
            //     TimeInMinutes = 260
            // };
            //
            //
            // Employee employee = new Employee()
            // {
            //     Id = 1,
            //     Birthday = new DateTime(2021 - 12 - 10),
            //     Branch = branch,
            //     City = "Bratislava",
            //     Country = "Slovakia",
            //     CPR = "21371488",
            //     Email = "chuj.chuj@gmail.com",
            //     FirstName = "chuj",
            //     LastName = "chujowski",
            //     Password = "123",
            //     TicketsSold = null
            // };
            //
            // User user = new User()
            // {
            //     Id = 1,
            //     Email = "jebo.jebowski@kokot.com",
            //     FirstName = "Jebo",
            //     LastName = "Jebowski",
            //     Password = "Pojebane123",
            //     TicketsPurchased = null
            // };
            //
            // Ticket ticket = new Ticket()
            // {
            //     Id = 1,
            //     Column = 6,
            //     Row = 4,
            //     Employee = employee,
            //     Play = play,
            //     User = user
            // };
            //
            // //***********
            // //API TESTING
            // //***********
            //
            // //***********
            // //BRANCH
            // //***********
            //
            // Task<Branch> createBranch = branchRequest.CreateBranch(branch);
            // Task<Branch> editBranch = branchRequest.EditBranch(branch);
            // Task<Branch> getBranch = branchRequest.GetBranch(1);
            // Task<IList<Branch>> getBranches = branchRequest.GetAllBranches();
            // Task<bool> deleteBranch = branchRequest.DeleteBranch(1);
            //
            // Console.WriteLine(createBranch);
            // Console.WriteLine(editBranch);
            // Console.WriteLine(getBranch);
            // foreach (Branch forBranch in getBranches.Result) {
            //     Console.WriteLine(forBranch);
            // }
            // Console.WriteLine(deleteBranch);
            //
            // //***********
            // //EMPLOYEE
            // //***********
            //
            // Task<Employee> createEmployee = employeeRequest.CreateEmployee(employee);
            // Task<Employee> editEmployee = employeeRequest.EditEmployee(employee);
            // Task<Employee> getEmployee = employeeRequest.GetEmployee(1);
            // Task<IList<Employee>> getEmployees = employeeRequest.GetAllEmployees();
            // Task<bool> deleteEmployee = employeeRequest.DeleteEmployee(1);
            //
            // Console.WriteLine(createEmployee);
            // Console.WriteLine(editEmployee);
            // Console.WriteLine(getEmployee);
            // foreach (Employee forEmployee in getEmployees.Result) {
            //     Console.WriteLine(forEmployee);
            // }
            //
            // Console.WriteLine(deleteEmployee);
            //
            //
            //
            //
            // //***********
            // //HALL
            // //***********
            //
            // Task<Hall> createHall = hallRequest.CreateHall(hall);
            // Task<Hall> editHall = hallRequest.EditHall(hall);
            // Task<Hall> getHall = hallRequest.GetHall(1);
            // Task<IList<Hall>> getHalls = hallRequest.GetAllHalls();
            // Task<bool> deleteHall = hallRequest.DeleteHall(1);
            //
            // Console.WriteLine(createHall);
            // Console.WriteLine(editHall);
            // Console.WriteLine(getHall);
            // foreach (Hall forHall in getHalls.Result) {
            //     Console.WriteLine(forHall);
            // }
            //
            // Console.WriteLine(deleteHall);
            //
            // //***********
            // //MOVIE
            // //***********
            //
            // Task<Movie> createMovie = movieRequest.CreateMovie(movie);
            // Task<Movie> editMovie = movieRequest.EditMovie(movie);
            // Task<Movie> getMovie = movieRequest.GetMovie(1);
            // Task<IList<Movie>> getMovies = movieRequest.GetAllMovies();
            // Task<bool> deleteMovie = movieRequest.DeleteMovie(1);
            //
            // Console.WriteLine(createMovie);
            // Console.WriteLine(editMovie);
            // Console.WriteLine(getMovie);
            // foreach (Movie forMovie in getMovies.Result) {
            //     Console.WriteLine(forMovie);
            // }
            //
            // Console.WriteLine(deleteMovie);
            //
            // //***********
            // //PLAY
            // //***********
            //
            // Task<Play> createPlay = playRequest.CreatePlay(play);
            // Task<Play> editPlay = playRequest.EditPlay(play);
            // Task<Play> getPlay = playRequest.GetPlay(1);
            // Task<IList<Play>> getPlays = playRequest.GetAllPlays();
            // Task<bool> deletePlay = playRequest.DeletePlay(1);
            //
            // Console.WriteLine(createPlay);
            // Console.WriteLine(editPlay);
            // Console.WriteLine(getPlay);
            // foreach (Play forPlay in getPlays.Result) {
            //     Console.WriteLine(forPlay);
            // }
            //
            // Console.WriteLine(deletePlay);
            //
            // //***********
            // //TICKET
            // //***********
            //
            // Task<Ticket> createTicket = ticketRequest.CreateTicket(ticket);
            // Task<Ticket> editTicket = ticketRequest.EditTicket(ticket);
            // Task<Ticket> getTicket = ticketRequest.GetTicket(1);
            // Task<IList<Ticket>> getTickets = ticketRequest.GetAllTickets();
            // Task<bool> deleteTicket = ticketRequest.DeleteTicket(1);
            //
            // Console.WriteLine(createTicket);
            // Console.WriteLine(editTicket);
            // Console.WriteLine(getTicket);
            // foreach (Ticket forTicket in getTickets.Result) {
            //     Console.WriteLine(forTicket);
            // }
            //
            // Console.WriteLine(deleteTicket);
            //
            // //***********
            // //USER
            // //***********
            //
            //
            //
            // Task<User> createUser = userRequest.RegisterUser(user);
            // Task<User> editUser = userRequest.EditUser(user);
            // Task<User> getUser = userRequest.GetUser(1);
            // Task<IList<User>> getUsers = userRequest.GetAllUsers();
            // Task<bool> deleteUser = userRequest.DeleteUser(1);
            // Task<User> loginUser = userRequest.Login(user);
            //
            // Console.WriteLine(createUser);
            // Console.WriteLine(editUser);
            // Console.WriteLine(getUser);
            // foreach (User forUser in getUsers.Result) {
            //     Console.WriteLine(forUser);
            // }
            //
            // Console.WriteLine(deleteUser);
            // Console.WriteLine(loginUser);

        }


        //please make the methods in order of the classes
        public async Task<Branch> CreateBranch(Branch branch)
        {
            try
            {
                return await branchRequest.CreateBranch(branch);
            }
            catch (Exception e)
            {
                ;
                return null;
            }
        }

        public async Task<Branch> EditBranch(Branch branch)
        {
            try
            {
                return await branchRequest.EditBranch(branch);
            }
            catch (Exception e)
            {
                ;
                return null;
            }
        }

        public async Task<bool> DeleteBranch(long branchId)
        {
            try
            {
                return await branchRequest.DeleteBranch(branchId);
            }
            catch (Exception e)
            {
                ;
                return false;
            }
        }

        public async Task<Branch> GetBranch(int branchId)
        {
            try
            {
                return await branchRequest.GetBranch(branchId);
            }
            catch (Exception e)
            {
                ;
                return null;
            }
        }

        public async Task<IList<Branch>> GetAllBranches()
        {
            try
            {
                return await branchRequest.GetAllBranches();
            }
            catch (Exception e)
            {
                ;
                return null;
            }
        }
        public async Task<User> RegisterUser(User user) {
            try {
                return await userRequest.RegisterUser(user);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<User> LoginUser(User user) {
            try {
                return await userRequest.Login(user);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<User> EditUser(User user) {
            try {
                return await userRequest.EditUser(user);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<bool> DeleteUser(int id) {
            try {
                return await userRequest.DeleteUser(id);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<User> GetUser(int id) {
            try {
                return await userRequest.GetUser(id);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<IList<User>> GetAllUsers() {
            try {
                return await userRequest.GetAllUsers();
            }
            catch (Exception e) {
                ;
                return null;
            }
        }


        public async Task<Movie> AddMovie(Movie movie) {
            try {
                return await movieRequest.CreateMovie(movie);
            }
            catch (Exception e) {
                ;
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
                ;
                return false;
            }
        }

        public async Task<Movie> GetMovie(int id) {
            try {
                return await movieRequest.GetMovie(id);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<IList<Movie>> GetAllMovies() {
            try {
                return await movieRequest.GetAllMovies();
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<Play> AddPlay(Play play) {
            try {
                return await playRequest.CreatePlay(play);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<Play> EditPlay(Play play) {
            try {
                return await playRequest.EditPlay(play);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<bool> DeletePlay(int id) {
            try {
                return await playRequest.DeletePlay(id);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<Play> GetPlay(int id) {
            try {
                return await playRequest.GetPlay(id);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<IList<Play>> GetAllPlays() {
            try {
                return await playRequest.GetAllPlays();
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<bool> AddProgram(Program program) {
            try {
                return await programRequest.CreateProgram(program);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<bool> EditProgram(Program program) {
            try {
                return await programRequest.EditProgram(program);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<bool> DeleteProgram(Program program) {
            try {
                return await programRequest.DeleteProgram(program);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<Program> GetProgram(int id) {
            try {
                return await programRequest.GetProgram(id);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<List<Program>> GetAllPrograms() {
            try {
                return await programRequest.GetAllPrograms();
            }
            catch (Exception e) {
                ;
                return null;
            }
        }
        
        public async Task<Ticket> AddTicket(Ticket ticket) {
            try {
                return await ticketRequest.CreateTicket(ticket);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<Ticket> EditTicket(Ticket ticket) {
            try {
                return await ticketRequest.EditTicket(ticket);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<bool> DeleteTicket(int movieId) {
            try {
                return await ticketRequest.DeleteTicket(movieId);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<Ticket> GetTicket(int ticketId) {
            try {
                return await ticketRequest.GetTicket(ticketId);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<IList<Ticket>> GetAllTickets() {
            try {
                return await ticketRequest.GetAllTickets();
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<Hall> AddHall(Hall hall) {
            try {
                return await hallRequest.CreateHall(hall);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<Hall> EditHall(Hall hall) {
            try {
                return await hallRequest.EditHall(hall);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<bool> DeleteHall(int id) {
            try {
                return await hallRequest.DeleteHall(id);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<Hall> GetHall(int hallId) {
            try {
                return await hallRequest.GetHall(hallId);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<IList<Hall>> GetAllHalls() {
            try {
                return await hallRequest.GetAllHalls();
            }
            catch (Exception e) {
                ;
                return null;
            }
        }
        public async Task<Employee> AddEmployee(Employee employee) {
            try {
                return await employeeRequest.CreateEmployee(employee);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<Employee> EditEmployee(Employee employee) {
            try {
                return await employeeRequest.EditEmployee(employee);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<bool> DeleteEmployee(int id) {
            try {
                return await employeeRequest.DeleteEmployee(id);
            }
            catch (Exception e) {
                ;
                return false;
            }
        }

        public async Task<Employee> GetEmployee(int employeeId) {
            try {
                return await employeeRequest.GetEmployee(employeeId);
            }
            catch (Exception e) {
                ;
                return null;
            }
        }

        public async Task<IList<Employee>> GetAllEmployees() {
            try {
                return await employeeRequest.GetAllEmployees();
            }
            catch (Exception e) {
                ;
                return null;
            }
        }
    }
}