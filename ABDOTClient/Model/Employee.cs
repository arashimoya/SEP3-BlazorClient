using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Employee : User
    {
        
        public int Role { get; private set; }
        
        [Required] public string CPR { get; set; }

        [Required] public string Street { get; set; }
        
        [Required] public string City { get; set; }
        
        [Required] public string Postcode { get; set; }
        
        [Required] public string Country { get; set; }

        [Required] public DateTime Birthday { get; set; }
        public IList<Ticket> TicketsSold { get; set; }

        public Branch Branch;

        public Employee()
        {
            TicketsSold = new List<Ticket>();
        }
    }
}