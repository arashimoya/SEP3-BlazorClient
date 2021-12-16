using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Branch
    {
        
      
        public int Id { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "City is to long.")]
        public string City { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "Enter valid postcode.")]
        public string Postcode { get; set; }
        [Required]
        [StringLength(25 , ErrorMessage = "Enter valid street")]
        [MinLength(3, ErrorMessage = "Enter valid street")]
        public string Street { get; set; }
        [Required]
        [StringLength(25 , ErrorMessage = "Enter valid Country")]
        [MinLength(3, ErrorMessage = "Enter valid Country")]
        public string Country { get; set; }
        
        public IList<Hall> Halls { get; set; }

        public IList<Employee> Employees { get; set; }

        public Branch()
        {
            Halls = new List<Hall>();
            Employees = new List<Employee>();
        }

        public override string ToString()
        {
            string returnString = "Branch{\nId : " + Id + "\n" + "City : " + City + "\n" + "Postcode : " + Postcode + "\n"
                                  + "Street : " + Street + "\n" + "Country : " + Country + "\n" + "Halls : " + Halls +
                                  "\n" + "Employees : " + Employees + "\n}";
            return returnString;
        }
    }
}