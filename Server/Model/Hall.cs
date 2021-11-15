using System.Collections.Generic;

namespace Server.Model
{
    public class Hall
    {
        public int Id { get; set; }
        public IList<Seat> Seats { get; set; }
    }
}