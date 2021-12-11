using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Branch
    {
        
      
        public int Id { get; set; }
        
        [Required]
        public string City { get; set; }
        
        public string Postcode { get; set; }
        
        public string Street { get; set; }
        
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