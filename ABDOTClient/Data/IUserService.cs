using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
        Task<bool> RegisterUser(string email, string password, string firstName, string lastName, 
            string streetAndHouseNumber, string city, string postcode, string country);
        public bool IsAlreadyInUse(string email);
    }
}