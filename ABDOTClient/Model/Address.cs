using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Address
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        
    }
}