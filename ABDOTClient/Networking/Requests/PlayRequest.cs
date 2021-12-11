using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace ABDOTClient.Networking.Requests {
    public class PlayRequest : IPlayRequest
    {
        private GraphQLHttpClient graphQlClient;
        private IList<Play> Plays;

        public PlayRequest()
        {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql", new NewtonsoftJsonSerializer());
            Plays = new List<Play>();
        }
        
        private class PlaysRoot
        {
            public List<Play> Plays { get; set; }

            public PlaysRoot() {
                Plays = new List<Play>();
            }
        }

        private class PlayRoot {
            public Play Play { get; set; }
        }

        private class DeleteRoot {
            public bool deletePlay { get; set; }
        }


        private class CreatePlayRoot {
            public Play createPlay { get; set; }
        }

        private class EditPlayRoot {
            public Play editPlay { get; set; }
        }
        
        
        public async Task<Play> CreatePlay(Play play) 
        {
            
            string query = @"
                        mutation ($date : String!, $timeInMinutes : Int!, $movieId : Long!, $hallId : Long!, $price : Int!) {
                          createPlay (play: {date : $date, timeInMinutes : $timeInMinutes, movieId : $movieId, hallId: $hallId, price: $price} ){
                            id,
                            timeInMinutes,
                            price,
                            movie {
                              id,
                              title,
                              description,
                              genre,
                              director,
                              language,
                              subtitleLanguage,
                              year,
                              lengthInMinutes,
                              posterSrc
                            }
                            hall {
                              id,
                              hallSize,

                            }
                          }
                        }
                        ";
            
            //Set variables
            var variables = new
            {
                date = play.Date.ToString(CultureInfo.InvariantCulture),
                timeInMinutes = play.TimeInMinutes,
                movieId = play.Movie.Id,
                hall = play.Hall.Id,
                price = play.Price
            };
            //Make request object out of content using custom method wrote by #me
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<CreatePlayRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<CreatePlayRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return, possibly print
            return graphQLResponse.Data.createPlay;

        }

        public async Task<Play> EditPlay(Play play)
        {
            string query = @"
                        mutation ($id : Long!, $firstName : String!, $lastName : String!, $email: String!, $password: String!) {
                          editUser(user: {id : $id, firstName: $firstName, email: $email, lastName: $lastName, password: $password}) {
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

        public async Task<bool> DeletePlay(int id)
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

        public async Task<Play> GetPlay(int id)
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
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<UserRoot>(graphQLRequest);
            //Return
            return graphQLResponse.Data.user;
            
        }

        public async Task<IList<Play>> GetAllPlays()
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