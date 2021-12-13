using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using ABDOTClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using LoginComponent;

namespace ABDOTClient.Networking {
    public class UserRequest : IUserRequest {
        private GraphQLHttpClient graphQlClient;
        private static readonly HttpClient httpClient = new HttpClient();
        private IList<User> Users;
        public UserRequest()
        {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql", new NewtonsoftJsonSerializer());
            Users = new List<User>();
        }
        
        
        private class UsersRoot
        {
            public List<User> users { get; set; }

            public UsersRoot()
            {
                users = new List<User>();
            }
        }

        private class UserRoot
        {
            public User user { get; set; }
        }

        private class DeleteRoot
        {
            public bool deleteUser { get; set; }
        }
        
        private class CreateUserRoot
        {
            //this has to be createBranch because thats how it comes from graphQL, same for edit branch...just query from banana cake and you will see what to put here
            public User createUser { get; set; }
        }

        private class EditUserRoot
        {
            //same here, also u can see how im calling this later when im printing/returning it
            public User editUser { get; set; }
        }

        private class LoginRoot
        {
            public User login { get; set; }   
        }
        
        
        
        public async Task<User> RegisterUser(User user)
        {
            string query = @"
                        mutation ($firstName : String!, $lastName : String!, $email: String!, $password: String!) {
                          createUser(user: {firstName: $firstName, email: $email, lastName: $lastName, password: $password}) {
                            id,
                            firstName,
                            lastName,
                            email,
                            password,
                            ticketsPurchased {
                              id
                            }
                          }
                        }
        
                        ";
            
            //Set variables
            var variables = new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                password = user.Password
            };
            //Make request object out of content using custom method wrote by #me
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<CreateUserRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<CreateUserRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return, possibly print
            Console.WriteLine(graphQLResponse.Data.createUser.FirstName);
            return graphQLResponse.Data.createUser;
            
        }

        public async Task<User> Login(User user)
        {
            Console.WriteLine(user.ToString());
            //Create content of the query
            string query = @"
                  mutation ($email : String!, $password: String!) {{
                      login (login : {email: $email, password: $password}) {
                        id,
                        firstName,
                        lastName,
                        email,
                        purchasedTickets {
                           id,
                           row,
                           column
}         
                        ";
            var variables = new
            {
                email = user.Email,
                password = user.Password
            };
            Console.WriteLine("XXXXXX");
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<LoginRoot>(graphQLRequest);
            //Return
            Console.WriteLine("YYYYYYYYY");
            Console.WriteLine(graphQLResponse.Data.login);
            Console.WriteLine("ZZZZZZZZZ");
            return graphQLResponse.Data.login;
        }

        public async Task<User> EditUser(User user)
        {
            string query = @"
                        mutation ($id : Long!, $firstName : String!, $lastName : String!, $email: String!, $password: String!) {
                          editUser(user: {id : $id, firstName: $firstName, email: $email, lastName: $lastName, password: $password}) {
                            id,
                            firstName,
                            lastName,
                            email,
                            password
                          }
                        }
         
                        ";
            
            //Set variables
            var variables = new
            {
                id = user.Id,
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                password = user.Password
            };
            //Make request object out of content using custom method wrote by #me
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<EditUserRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<EditUserRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return, possibly print
            Console.WriteLine(graphQLResponse.Data.editUser.FirstName);
            return graphQLResponse.Data.editUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            //set query
            string query = @"
                        mutation ($userId : Long!) {
                          deleteUser (userId : $userId)
                        }          
                        ";
            
            //Set variables
            var variables = new
            {
                userId = id
            };
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request
            var graphQLResponse = new GraphQLResponse<DeleteRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<DeleteRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return
            Console.WriteLine(graphQLResponse.Data.deleteUser);
            return graphQLResponse.Data.deleteUser;
        }

        public async Task<User> GetUser(int userId)
        {
            //set query
            string query = @"
                query ($id : Int!) {
                  user (id: $id){
                    firstName,
                    lastName,
                    email,
                    ticketsPurchased {
                      id
                    }
                  }
                }            
                        ";

            var variables = new
            {
                id = userId
            };
            
            
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<UserRoot>(graphQLRequest);
            //Return
            return graphQLResponse.Data.user;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            //Create content of the query
            string query = @"
                  query {
                      users {
                        firstName,
                        lastName,
                        email,
                        ticketsPurchased {
                          id
                        }
                      }
                    }          
                        ";
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<UsersRoot>(graphQLRequest);
            //Return
            return graphQLResponse.Data.users;
        }
        
    }
}