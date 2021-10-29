using ABDOTClient.Model;

namespace Assignment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string email, string password);
        void RegisterUser(string email, string password, string firstName, string lastName, 
            string streetAndHouseNumber, string city, string postcode, string country);
        public bool IsAlreadyInUse(string email);
    }
}