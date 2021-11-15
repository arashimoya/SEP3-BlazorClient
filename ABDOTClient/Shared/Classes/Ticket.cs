using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABDOTClient.Shared.Classes
{
    public class Ticket
    {
        private int id { set; get; }
        private Movie movie { set; get; }
        private Branch branch { set; get; }
        private Seat seat { set; get; }
        private Customer customer { set; get; }

        public Ticket(int id, Movie movie, Branch branch,Seat seat, Customer customer)
        {
            this.id = id;
            this.movie = movie;
            this.branch = branch;
            this.seat = seat;
            this.customer = customer;
        }

    }
}