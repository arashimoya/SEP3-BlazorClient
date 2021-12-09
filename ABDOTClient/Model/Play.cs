using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Play
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TimeInMinutes { get; set; }
        
        [Required]
        public Movie Movie { get; set; }
        
        [Required]
        public Hall Hall { get; set; }

        public IList<Ticket> Tickets { get; set; }

        public Play()
        {
            Tickets = new List<Ticket>();
        }
    }
}