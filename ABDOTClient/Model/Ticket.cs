using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABDOTClient.Model
{
    public class Ticket
    {
        public int Id { set; get; }
        public Play Play { set; get; }
        public Branch Branch { set; get; }
        public Seat Seat { set; get; }
        public User User { set; get; }
    }
}