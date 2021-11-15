using System;

namespace ABDOTClient.Shared.Classes
{
    public class Operator : Employee 
    {
        public Operator(string FirstName, string LastName, string Email, string Password, string Street,
            string City,
            string PostCode, string Country, int id, string Role, string CPR, DateTime BirthDate) : base(FirstName,LastName,Email,Password,Street,City,PostCode,Country,id,Role,CPR,BirthDate)
        {}
    }
}