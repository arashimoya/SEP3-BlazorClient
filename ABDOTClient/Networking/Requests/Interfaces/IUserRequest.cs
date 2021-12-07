using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking
{
    public interface IUserRequest
    {
        Task<bool> RegisterUser(User user);

        Task<bool> EditUser(User user);

        Task<bool> DeleteUser(User user);

        Task<User> GetUser(int id);

        Task<IList<User>> GetAllUsers();
        Task<User> Login(User user);
    }
}