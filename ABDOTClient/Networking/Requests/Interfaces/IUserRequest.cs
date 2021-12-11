using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking
{
    public interface IUserRequest
    {
        Task<User> RegisterUser(User user);

        Task<User> EditUser(User user);

        Task<bool> DeleteUser(int id);

        Task<User> GetUser(int id);

        Task<IList<User>> GetAllUsers();
        Task<User> Login(User user);
    }
}