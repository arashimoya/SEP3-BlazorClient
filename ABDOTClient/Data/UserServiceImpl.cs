using System;
using System.Collections.Generic;
using System.Linq;
using ABDOTClient.Model;
using ABDOTClient.Persistence;
using Assignment1.Data;


namespace ABDOTClient.Data
{
    public class UserServiceImpl : IUserService
    {
        
        private List<User> users;
        private ServerContext ServerContext;

        public UserServiceImpl()
        {
            ServerContext = new ServerContext();
        }
        
        
        
        User IUserService.ValidateUser(string email, string password)
        {
            User first = ServerContext.Users.FirstOrDefault(user => user.Email.Equals(email));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        public void RegisterUser(string email, string password, string firstName, string lastName, 
            string street, string city, string postcode, string country)
        {
            User freshUser = new User();
            freshUser.Email = email;
            freshUser.Password = password;
            freshUser.FirstName = firstName;
            freshUser.LastName = lastName;
            freshUser.City = city;
            freshUser.Country = country;
            freshUser.Postcode = postcode;
            freshUser.Street = street;
            
            Console.WriteLine(freshUser.ToString());
            //THEN add user to database via Server
        }

        public bool IsAlreadyInUse(string email)
        {
            User first = ServerContext.Users.FirstOrDefault(user => user.Email.Equals(email));
            if (first == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}