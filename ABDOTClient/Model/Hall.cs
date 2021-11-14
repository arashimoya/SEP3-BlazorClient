using System.Collections.Generic;

namespace ABDOTClient.Model
{
    public class Hall
    {
        public int Id { get; set; }
        public IList<Seat> Seats { get; set; }
    }
}