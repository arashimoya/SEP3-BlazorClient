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
        public Employee Employee { set; get; }
        public int Row { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            string returnString = "Ticket{\nId : " + Id + "\nPlay : " + Play + "\nEmployee" + Employee + "\nRow" + Row
                           + "\nColumn" + Column + "\n}";
            return returnString;
        }
    }
}