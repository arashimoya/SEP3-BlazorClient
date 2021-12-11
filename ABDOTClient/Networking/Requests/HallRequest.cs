using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace ABDOTClient.Networking.Requests {
    public class HallRequest : IHallRequest {
        private class HallsRoot {
            public List<Hall> Halls { get; set; }

            public HallsRoot() {
                Halls = new List<Hall>();
            }
        }

        private class HallRoot {
            public Hall Hall { get; set; }
        }

        private class DeleteRoot {
            public bool deleteHall { get; set; }
        }


        private class CreateHallRoot {
            public Hall createHall { get; set; }
        }

        private class EditHallRoot {
            public Hall editHall { get; set; }
        }


        private IList<Hall> Halls;
        private GraphQLHttpClient graphQlClient;


        public HallRequest() {
            Halls = new List<Hall>();
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql",
                new NewtonsoftJsonSerializer());
        }

        public async Task<Hall> CreateHall(Hall hall) {
            var query =
                @"mutation($branchId : Int!, $hallSize: Int!) {
                  createHall (input : {branchId : $branchId, hallSize:$hallSize}) {
                    id,
                    hallSize,
                    branch{
                      id,
                      street,
                      city,
                      postcode,
                      country
                    }
                  }
                 }";
            var variables = new {
                branchId = hall.Branch.Id,
                hallSize = hall.HallSize
            };

            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<CreateHallRoot>();
            try {
                graphQLResponse = await graphQlClient.SendMutationAsync<CreateHallRoot>(graphQLRequest);
            }
            catch (Exception e) {
                Console.WriteLine(e.Data);
                throw;
            }

            Console.WriteLine(graphQLResponse.Data.createHall.Id);
            //Return, possibly print
            return graphQLResponse.Data.createHall;
        }

        public async Task<Hall> EditHall(Hall hall) {
            var query =
                @"mutation($id:Int!,$branchId : Int!, $hallSize: Int!) {
                    editHall (input : {id:$id  ,branchId : $branchId, hallSize:$hallSize}) {
                    id,
                    hallSize,
                    branch{
                      id,
                      street,
                      city,
                      postcode,
                      country
                    }
                  }
                 }";
            var variables = new {
                id = hall.Id,
                branchId = hall.Branch.Id,
                hallSize = hall.HallSize
            };

            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<EditHallRoot>();
            try {
                graphQLResponse = await graphQlClient.SendMutationAsync<EditHallRoot>(graphQLRequest);
            }
            catch (Exception e) {
                Console.WriteLine(e.Data);
                throw;
            }

            Console.WriteLine(graphQLResponse.Data.editHall.Id);
            //Return, possibly print
            return graphQLResponse.Data.editHall;
        }

        public async Task<bool> DeleteHall(int hallId) {
            //set query
            string query = @"
                        mutation($id: Int!){
                        deleteHall(id:$id)
                        }         
                        ";

            //Set variables
            var variables = new {
                id = hallId
            };
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            //Send request
            var graphQLResponse = new GraphQLResponse<DeleteRoot>();
            try {
                graphQLResponse = await graphQlClient.SendMutationAsync<DeleteRoot>(graphQLRequest);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }

            //Return
            return graphQLResponse.Data.deleteHall;
        }

        public async Task<Hall> GetHall(int hallId) {
            //Create content of the query
            string query = @"
                  query($id:Int!){
                  hall(id:$id){
                    id,
                    hallSize,
                    branch{
                      id
                    },
                    programme{
                      movie{
                        title,
                        lengthInMinutes,
                      },
                      timeInMinutes,
                      price,
                      tickets{
                        row,
                        column,
                      }
                    }

                  }
                  
                }            
                        ";

            var variables = new {
                id = hallId
            };
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            var graphQLResponse = await graphQlClient.SendQueryAsync<HallRoot>(graphQLRequest);
            Hall hall = graphQLResponse.Data.Hall;
            hall.LoadSeats();
            return hall;
        }

        public async Task<IList<Hall>> GetAllHalls() {
            string query = @"
                query{
                  halls{
                    id,
                    hallSize,
                    branch{
                      id
                    },
                    programme{
                      movie{
                        title,
                        lengthInMinutes,
                      },
                      timeInMinutes,
                      price,
                      tickets{
                        row,
                        column,
                      }
                    }

                  }
                  
                }            
                        ";
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            var graphQLResponse = await graphQlClient.SendQueryAsync<HallsRoot>(graphQLRequest);
            List<Hall> halls = graphQLResponse.Data.Halls;
            foreach (var hall in halls) {
                hall.LoadSeats();
            }

            return halls;
        }
    }
}