using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Employee
    {
        
        [Required] public int Id { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        public string Password { get; set; }

        public int Role { get; set; }
        
        [Required] public string CPR { get; set; }

        [Required] public string Street { get; set; }
        
        [Required] public string City { get; set; }
        
        [Required] public string Postcode { get; set; }
        
        [Required] public string Country { get; set; }

        [Required] public DateTime Birthday { get; set; }
        public IList<Ticket> TicketsSold { get; set; }

        public Branch Branch { get; set; }

        public Employee()
        {
            TicketsSold = new List<Ticket>();
        }

        public override string ToString()
        {
            string returnString = "Employee{\nId : " + Id + "\nEmail : " + Email + "\n FirstName : " + FirstName
                                  + "\nLastName : " + LastName + "\n Password : " + Password + "\nRole : " + Role +
                                  "\nCPR : " + CPR + "\nStreet : " + Street + "\nCity : " + City + "\nPostcode : " +
                                  Postcode
                                  + "\nCountry : " + "\nBirthday : " + Birthday + "\nTicketsSold : " + TicketsSold +
                                  "\nBranch : " + Branch + "\n}";
            return returnString;
        }
    }
}