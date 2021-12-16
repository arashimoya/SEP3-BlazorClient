using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Employee
    {
        
        [Required] public int Id { get; set; }
        [EmailAddress]
        [Required] public string Email { get; set; }
        [Range(1,20,ErrorMessage = "Enter valid name")]
        [Required] public string FirstName { get; set; }
        [Range(1,25,ErrorMessage = "Enter valid name")]
        [Required] public string LastName { get; set; }
        [Required] public string Password { get; set; }
        [Range(1,3,ErrorMessage = "Role should be between 1 and 3")]
        [Required]  public int Role { get; set; }
        [StringLength(10, ErrorMessage = "Enter valid CPR")]
        [MinLength(10, ErrorMessage = "Enter valid CPR")]
        [Required] public string CPR { get; set; }
        [StringLength(25, ErrorMessage = "Enter valid street")]
        [MinLength(5, ErrorMessage = "Enter valid street")]
        [Required] public string Street { get; set; }
        [StringLength(25, ErrorMessage = "Enter valid city")]
        [MinLength(3, ErrorMessage = "Enter valid city")]
        [Required] public string City { get; set; }
        [StringLength(7, ErrorMessage = "Enter valid postcode")]
        [MinLength(3, ErrorMessage = "Enter valid postcode")]
        [Required] public string Postcode { get; set; }
        [StringLength(25, ErrorMessage = "Enter valid Country")]
        [MinLength(3, ErrorMessage = "Enter valid Country")]
        [Required] public string Country { get; set; }
        [StringLength(10, ErrorMessage = "Enter valid birthday")]
        [MinLength(1, ErrorMessage = "Enter valid birthday")]
        [Required] public string Birthday { get; set; }
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