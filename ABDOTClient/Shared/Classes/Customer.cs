namespace ABDOTClient.Shared.Classes
{
    public class Customer : Person
    {
        Customer(int id, string FirstName, string LastName, string Email, string Password, string Street, string City,
            string PostCode, string Country) : base(id, FirstName, LastName, Email, Password, Street, City, PostCode,
            Country)
        {
            
        }
    }
}