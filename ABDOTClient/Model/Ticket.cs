using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABDOTClient.Model
{
    public class Ticket
    {
        public int id { set; get; }
        public Movie movie { set; get; }
        public Branch branch { set; get; }
        public Seat seat { set; get; }
        public Customer customer { set; get; }

       
    }
}