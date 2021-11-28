using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABDOTClient.Model
{
    public class Ticket
    {
        
        public int Id {private set; get; }
        
        [Required]
        public Play Play { set; get; }
        public User User { set; get; }
        public Employee Employee { set; get; }
        
        [Required]
        public Tuple<int, int> seat { get; set; }
    }
}