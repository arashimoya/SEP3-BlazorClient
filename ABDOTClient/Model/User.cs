using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model{
    public class User{
        [Required] public int Id { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        public string Password { get; set; }
        
        public IList<Ticket> TicketsPurchased { get; set; }

        public User()
        {
            TicketsPurchased = new List<Ticket>();
        }

        public override string ToString()
        {
            string returnString = "User{\nId : " + Id + "\nEmail : " + Email + "\nFirstName : " + FirstName
                                  + "\nLastname : " + LastName + "\nPassword : " + Password + "\nTicketsPurchased : " +
                                  TicketsPurchased + "\n}";
            return returnString;
        }
    }
}