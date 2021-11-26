

namespace ABDOTClient.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public Play Play { get; set; }
        public Branch Branch { get; set; }
        public Hall Hall { get; set; }
        public Seat Seat { get; set; }
        public User Customer { get; set; }
        
    }
}