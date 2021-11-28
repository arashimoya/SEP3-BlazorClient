using System;
using System.Collections.Generic;

namespace ABDOTClient.Model
{
    public class Employee : User
    {
        public int Role { get; set; }
        public string CPR { get; set; }
        public DateTime Birthday { get; set; }

        public IList<Ticket> TicketsSold { get; set; }

        public Branch Branch;

        public Employee()
        {
            TicketsSold = new List<Ticket>();
        }
    }
}