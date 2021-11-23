using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model {
    public class Person {
        [Required] public int Id { get; private set; }
        [Required] public string Email { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Street { get; set; }
        public string Password { get; set; }
        [Required] public string Postcode { get; set; }
        [Required] public string Settlement { get; set; }
        [Required] public string Country { get; set; }
    }
}