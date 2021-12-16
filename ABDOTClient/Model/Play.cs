using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Play
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(25, ErrorMessage = "Enter valid date")]
        [MinLength(5, ErrorMessage = "Enter valid date")]
        public string Date { get; set; }

        [Required]
        public int TimeInMinutes { get; set; }
        
        [Required]
        public Movie Movie { get; set; }
        
        [Required]
        public Hall Hall { get; set; }
        [Required]
        
        public int Price { get; set; }

        public IList<Ticket> Tickets { get; set; }

        public Play()
        {
            Tickets = new List<Ticket>();
        }

        public override string ToString()
        {
            string returnString = "Play{\nId : " + Id + "\nDate : " + Date + "\nTimeInMinutes : "  + TimeInMinutes + "\nMovie : " + Movie
                                  + "\nHall ID :  " + Hall + "\nTickets" + Tickets + "\n}";
            return returnString;
        }
    }
}