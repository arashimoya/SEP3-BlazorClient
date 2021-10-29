using System;
using System.Collections.Generic;
using System.Linq;
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


        User IUserService.ValidateUser(string email, string password){
            User first = ServerContext.Users.FirstOrDefault(user => user.Email.Equals(email));
            if (first == null){
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)){
                throw new Exception("Incorrect password");
            }

            return first;
        }

        public void RegisterUser(string email, string password, string firstName, string lastName,
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