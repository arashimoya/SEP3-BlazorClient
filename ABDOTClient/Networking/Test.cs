using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Networking.Requests;
using ABDOTClient.Networking.Requests.Interfaces;

namespace ABDOTClient.Networking
{
    public class Test
    {
        private IMovieRequest movieRequest;
        private IPlayRequest playRequest;
        private IProgramRequest programRequest;
        private ITicketRequest ticketRequest;
        private IEmployeeRequest employeeRequest;
        private IHallRequest hallRequest;
        private IBranchRequest branchRequest;


        public Test()
        {
        
            movieRequest = new MovieRequest();
            playRequest = new PlayRequest();
            ticketRequest = new TicketRequest();
            employeeRequest = new EmployeeRequest();
            hallRequest = new HallRequest();
            branchRequest = new BranchRequest();
            
        }
        
        public async Task Tests()
        {
            Branch branch = new Branch()
             {
                 Id = 1,
                 City = "Horsens",
                 Street = "Ny Havnegade 21",
                 Postcode = "8700",
                 Country = "Denmark"
             };
            
             Hall hall = new Hall()
             {
                 Id = 1,
                 Branch = branch,
                 Programme = null
             };
             Movie movie = new Movie()
             {
                 Id = 1,
                 Title =  "King Kong",
                 Description = "King Kong",
                 Genre = "Thriller",
                 Director = "Tarantino",
                 Language = "English",
                 SubtitleLanguage = "Danish",
                 Year = 1992,
                 LengthInMinutes = 132,
                 PosterSrc = "Image"
             };
             Play play = new Play()
             {
                 Id = 1,
                 Date = "2012-12-20",
                 Hall = hall,
                 Movie = movie,
                 TimeInMinutes = 260,
                 Price = 50
             };
            
            
             Employee employee = new Employee()
             {
                 Id = 1,
                 Birthday = "2000-18-10",
                 Branch = branch,
                 City = "Bratislava",
                 Country = "Slovakia",
                 CPR = "21371488",
                 Email = "email@gmail.com",
                 FirstName = "Oliver",
                 LastName = "Sperlik",
                 Password = "123",
                 TicketsSold = null
             };

             Ticket ticket = new Ticket()
             {
                 Id = 1,
                 Column = 3,
                 Row = 4,
                 Play = play
             };
            
            
            
             //***********
             //API TESTING
             //***********
            
             //***********
             //BRANCH
             //***********
            
             Branch createBranch = await branchRequest.CreateBranch(branch);
             Branch editBranch = await branchRequest.EditBranch(branch);
             Branch getBranch = await branchRequest.GetBranch(1);
             IList<Branch> getBranches = await branchRequest.GetAllBranches();
             bool deleteBranch = await  branchRequest.DeleteBranch(1);
            
             Console.WriteLine(createBranch);
             Console.WriteLine(editBranch);
             Console.WriteLine(getBranch);
             foreach (Branch forBranch in getBranches) {
                 Console.WriteLine(forBranch);
             }
             Console.WriteLine(deleteBranch);
            
             //***********
             //EMPLOYEE
             //***********
            
             Employee createEmployee = await employeeRequest.CreateEmployee(employee);
             Employee editEmployee = await employeeRequest.EditEmployee(employee);
             Employee getEmployee = await employeeRequest.GetEmployee(1);
             IList<Employee> getEmployees = await employeeRequest.GetAllEmployees();
             bool deleteEmployee = await employeeRequest.DeleteEmployee(1);
            
             Console.WriteLine(createEmployee);
             Console.WriteLine(editEmployee);
             Console.WriteLine(getEmployee);
             foreach (Employee forEmployee in getEmployees) {
                 Console.WriteLine(forEmployee);
             }
            
             Console.WriteLine(deleteEmployee);
            
            
            
            
             //***********
             //HALL
             //***********
            
             Hall createHall = await hallRequest.CreateHall(hall);
             Hall editHall = await hallRequest.EditHall(hall);
             Hall getHall = await hallRequest.GetHall(1);
             IList<Hall> getHalls = await hallRequest.GetAllHalls();
             bool deleteHall = await hallRequest.DeleteHall(1);
            
             Console.WriteLine(createHall);
             Console.WriteLine(editHall);
             Console.WriteLine(getHall);
             foreach (Hall forHall in getHalls) {
                 Console.WriteLine(forHall);
             }
            
             Console.WriteLine(deleteHall);
            
             //***********
             //MOVIE
             //***********
            
             Movie createMovie = await movieRequest.CreateMovie(movie);
             Movie editMovie = await movieRequest.EditMovie(movie);
             Movie getMovie = await movieRequest.GetMovie(1);
             IList<Movie> getMovies = await movieRequest.GetAllMovies();
             bool deleteMovie = await movieRequest.DeleteMovie(1);
            
             Console.WriteLine(createMovie);
             Console.WriteLine(editMovie);
             Console.WriteLine(getMovie);
             foreach (Movie forMovie in getMovies) {
                 Console.WriteLine(forMovie);
             }
            
             Console.WriteLine(deleteMovie);
            
             //***********
             //PLAY
             //***********
            
             Play createPlay = await playRequest.CreatePlay(play);
             Play editPlay = await playRequest.EditPlay(play);
             Play getPlay = await playRequest.GetPlay(1);
             IList<Play> getPlays = await playRequest.GetAllPlays();
             bool deletePlay = await playRequest.DeletePlay(1);
            
             Console.WriteLine(createPlay);
             Console.WriteLine(editPlay);
             Console.WriteLine(getPlay);
             foreach (Play forPlay in getPlays) {
                 Console.WriteLine(forPlay);
             }
            
             Console.WriteLine(deletePlay);
            
             //***********
             //TICKET
             //***********
            
             Ticket createTicket = await ticketRequest.CreateTicket(ticket);
             Ticket editTicket = await ticketRequest.EditTicket(ticket);
             Ticket getTicket = await ticketRequest.GetTicket(1);
             IList<Ticket> getTickets = await ticketRequest.GetAllTickets();
             bool deleteTicket = await ticketRequest.DeleteTicket(1);
            
             Console.WriteLine(createTicket);
             Console.WriteLine(editTicket);
             Console.WriteLine(getTicket);
             foreach (Ticket forTicket in getTickets) {
                 Console.WriteLine(forTicket);
             }
            
             Console.WriteLine(deleteTicket);
        }
    }
}