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
        private IMovieRequest movieRequest;
        private IPlayRequest playRequest;
        private IProgramRequest programRequest;
        private ITicketRequest ticketRequest;
        private IEmployeeRequest employeeRequest;
        private IHallRequest hallRequest;
        private IBranchRequest branchRequest;
        private Test test;

        public Client()
        {
            movieRequest = new MovieRequest();
            playRequest = new PlayRequest();
            ticketRequest = new TicketRequest();
            employeeRequest = new EmployeeRequest();
            hallRequest = new HallRequest();
            branchRequest = new BranchRequest();
            test = new Test();
            
            // test.Tests();
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

        public async Task<Employee> LoginEmployee(Employee employee)
        {
            try
            {
                return await employeeRequest.LoginEmployee(employee);
            }
            catch (Exception e)
            {
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