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
        

        public PlayRequest()
        {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql", new NewtonsoftJsonSerializer());
            
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
                            date,
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
                              hallSize

                            }
                          }
                        }
                        ";
            
            //Set variables
            var variables = new
            {
                date = play.Date,
                timeInMinutes = play.TimeInMinutes,
                movieId = play.Movie.Id,
                hallId = play.Hall.Id,
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
                        mutation ($id : Long!, $date : String!, $timeInMinutes : Int!, $movieId : Long!, $hallId : Long!, $price : Int!) {
  editPlay (play: {id : $id, date : $date, timeInMinutes : $timeInMinutes, movieId : $movieId, hallId: $hallId, price: $price} ){
    id,
    timeInMinutes,
    price,
       date,
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
                id = play.Id,
                date = play.Date,
                timeInMinutes = play.TimeInMinutes,
                movieId = play.Movie.Id,
                hall = play.Hall.Id,
                price = play.Price
            };
            
            //Make request object out of content using custom method wrote by #me
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            //Send request, keep wrapped in try catch otherwise u wont get exception
            var graphQLResponse = new GraphQLResponse<EditPlayRoot>();
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<EditPlayRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //Return, possibly print
            return graphQLResponse.Data.editPlay;
        }

        public async Task<bool> DeletePlay(int playId)
        {
            
            //set query
            string query = @"
                        mutation ($id : Long!) {
                          deletePlay(playId: $id)
                        }         
                        ";
            
            //Set variables
            var variables = new
            {
                id = playId
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
            return graphQLResponse.Data.deletePlay;
            
        }

        public async Task<Play> GetPlay(int playId)
        {
            
            //set query
            string query = @"
                query ($id : Int!) {
  play(id : $id){
    id,
    timeInMinutes,
    price,
    date,
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
      hallSize

    }
  }
} ";

            var variables = new
            {
                id = playId
            };
            
            
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<PlayRoot>(graphQLRequest);
            //Return
            return graphQLResponse.Data.Play;
            
        }

        public async Task<IList<Play>> GetAllPlays()
        {
            //Create content of the query
            string query = @"
                  query {
  plays {
        id,
    timeInMinutes,
    price,
     date,
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
}";
            //Make request object out of content
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            //Send request
            var graphQLResponse = await graphQlClient.SendQueryAsync<PlaysRoot>(graphQLRequest);
            //Return
            
            return graphQLResponse.Data.Plays;
        }
    }
}