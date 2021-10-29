using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class User
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public string Password { get; set; }
    }
}