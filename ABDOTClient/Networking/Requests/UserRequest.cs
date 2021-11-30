using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class UserRequest : IUserRequest {
        private static readonly HttpClient httpClient = new HttpClient();
        private IList<User> Users;
        public UserRequest()
        {
            Users = new List<User>();
        }
        
        public async Task<bool> RegisterUser(User user)
        {
            if (Users.Contains(user)) return false;
            Users.Add(user);
            return true;
        }

        public async Task<User> Login(User user)
        {
            User toLogin = Users.FirstOrDefault(u => u.Email == user.Email);
            if (toLogin == null) throw new Exception("Wrong username!");
            if (!toLogin.Password.Equals(user.Password)) throw new Exception("Wrong password!");
            return toLogin;

        }

        public async Task<bool> EditUser(User user)
        {
            User toUpdate = Users.FirstOrDefault(u => u.Id == user.Id);
            if (toUpdate == null) return false;
            toUpdate.Email = user.Email;
            toUpdate.Password = user.Password;
            toUpdate.FirstName = user.FirstName;
            toUpdate.LastName = user.LastName;
            toUpdate.TicketsPurchased = user.TicketsPurchased;
            return true;
        }

        public async Task<bool> DeleteUser(User user)
        {
            User toRemove = Users.FirstOrDefault(u => u.Id == user.Id);
            if (toRemove == null) return false;
            Users.Remove(user);
            return true;
        }

        public async Task<User> GetUser(int id)
        {
            User toReturn = Users.FirstOrDefault(u => u.Id == id);
            if (toReturn == null) throw new Exception("Could not find a user with given Id");
            return toReturn;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            return Users;
        }
        
    }
}