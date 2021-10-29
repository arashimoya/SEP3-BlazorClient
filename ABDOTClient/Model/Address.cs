using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Address
    {
        [Required]
        public string StreetAndHouseNumber { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        
    }
}