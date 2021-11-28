using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class UserRequest : IUserRequest {
        private static readonly HttpClient httpClient = new HttpClient();
        
        public UserRequest() {
            
        }
        
        public async Task<bool> RegisterUser(User user) {
            throw new NotImplementedException();
        }

        public async Task<User> Login(User user) {
            throw new NotImplementedException();
        }

        public async Task<bool> EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        
    }
}