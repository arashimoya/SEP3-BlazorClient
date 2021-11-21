using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Networking;
using ABDOTClient.Persistence;

namespace ABDOTClient.Data {
    public class UserServiceImpl : IUserService {
        private List<User> users;
        private ServerContext ServerContext;
        private Client client;

        public UserServiceImpl() {
            ServerContext = new ServerContext();
            client = new Client();
            client.RunClient();
        }


        public async Task<User> ValidateUser(string email, string password) {
            var user = new User();
            user.Email = email;
            user.Password = password;
            var loggedUser = client.LoginUser("login", user);
            return loggedUser;
        }

        public async Task<bool> RegisterUser(string email, string password, string firstName, string lastName,
            string street, string city, string postcode, string country) {
            Console.WriteLine("creating...");
            var freshUser = new User {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                City = city,
                Country = country,
                Postcode = postcode,
                Street = street
            };
            return client.RegisterUser("register", freshUser);
        }

        public bool IsAlreadyInUse(string email) {
            User first = ServerContext.Users.FirstOrDefault(user => user.Email.Equals(email));
            if (first == null) {
                return false;
            }

            return true;
        }
    }
}