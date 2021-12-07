using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABDOTClient.Model
{
    public class Branch
    {
        
      
        public int Id { get; private set; }
        
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
    }
}