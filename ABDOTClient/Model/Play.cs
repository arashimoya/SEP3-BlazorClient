using System;
using System.Collections.Generic;

namespace ABDOTClient.Model
{
    public class Play
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TimeInMinutes { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }

        public IList<Ticket> Tickets { get; set; }

        public Play()
        {
            Tickets = new List<Ticket>();
        }
    }
}