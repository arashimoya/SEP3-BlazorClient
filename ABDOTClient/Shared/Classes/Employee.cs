using System;

namespace ABDOTClient.Shared.Classes
{
    public class Employee : Person
    {
        
        private string Role { set; get; }
        private string CPR { set; get; }
        private DateTime BirthDate { set; get; }

        public Employee(string FirstName, string LastName, string Email, string Password, string Street,
            string City,
            string PostCode, string Country, int id, string Role, string CPR, DateTime BirthDate) : base(id, FirstName,
            LastName, Email, Password, Street, City, PostCode, Country)
        {
            this.Role = Role;
            this.CPR = CPR;
            this.BirthDate = BirthDate;
        } 
    }
}