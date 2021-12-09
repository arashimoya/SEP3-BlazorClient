using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABDOTClient.Model
{
    public class Ticket
    {
        
        public int Id {set; get; }
        
        [Required]
        public Play Play { set; get; }
        public User User { set; get; }
        public Employee Employee { set; get; }
        // public Tuple<int, int> seat { get; set; }
        [Required] public int row { get; set; }
        [Required] public int column { get; set; }
    }
}