using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Networking;
using ABDOTClient.Persistence;

namespace ABDOTClient.Data{
    public class UserServiceImpl : IUserService{
        private List<User> users;
        private ServerContext ServerContext;
        private Client client;

        public UserServiceImpl()
            //TODO client not here 
        {
            ServerContext = new ServerContext();
            client = new Client();
            client.RunClient();
        }


        public async Task<User> ValidateUser(string email, string password)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;

            User loggedUser = await client.LoginUser(user);
            return loggedUser;
        }

        public bool RegisterUser(string email, string password, string firstName, string lastName,
            string street, string city, string postcode, string country){
            Console.WriteLine("creating...");
            User freshUser = new User();
            freshUser.Email = email;
            freshUser.Password = password;
            freshUser.FirstName = firstName;
            freshUser.LastName = lastName;
            freshUser.City = city;
            freshUser.Country = country;
            freshUser.Postcode = postcode;
            freshUser.Street = street;

            if (client.RegisterUser(freshUser)){
                return true;
            }

            return false;
        }

        public bool IsAlreadyInUse(string email){
            User first = ServerContext.Users.FirstOrDefault(user => user.Email.Equals(email));
            if (first == null){
                return false;
            }
            else{
                return true;
            }
        }
    }
}