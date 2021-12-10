using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace ABDOTClient.Networking
{
    public class MovieRequest : IMovieRequest
    {
        private class MoviesRoot
        {
            public List<Movie> movies { get; set; }

            public MoviesRoot()
            {
                movies = new List<Movie>();
            }
        }

        private class MovieRoot
        {
            public Movie movie { get; set; }
        }

        private class DeleteMovieRoot
        {
            public bool deleteMovie { get; set; }
        }

        private class CreateMovieRoot
        {
            public Movie createMovie { get; set; }
        }

        private class EditMovieRoot
        {
            public Movie editMovie { get; set; }
        }

        private GraphQLHttpClient graphQlClient;

        // private static readonly HttpClient httpClient = new HttpClient();
        private IList<Movie> Movies;

        public MovieRequest()
        {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql",
                new NewtonsoftJsonSerializer());
            Movies = new List<Movie>();
            // if (!Movies.Any()) Seed();
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            string query = @"mutation ($title : String!, $description: String!, $genre : String!, 
                $director : String!, $language : String!, $subtitleLanguage : String, $year : Int!,
                 $lengthInMinutes : Int!, $posterSrc : String)
                {
                  createMovie(input : {title : $title, description : $description,
                  genre : $genre, director : $director, language : $language, subtitleLanguage : $subtitleLanguage, 
                  year : $year, lengthInMinutes : $lengthInMinutes, posterSrc : $posterSrc})
                  {
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
                }";

            var variables = new
            {
                title = movie.Title,
                description = movie.Description,
                genre = movie.Genre,
                director = movie.Director,
                language = movie.Language,
                subtitleLanguage = movie.SubtitleLanguage,
                year = movie.Year,
                lengthInMinutes = movie.LengthInMinutes,
                posterSrc = movie.PosterSrc
            };

            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            var graphQLResponse = new GraphQLResponse<CreateMovieRoot>();

            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<CreateMovieRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return graphQLResponse.Data.createMovie;
        }

        public async Task<Movie> EditMovie(Movie movie)
        {
            string query = @"mutation ($id : Int!, $title : String!, $description: String!, $genre : String!, 
                $director : String!, $language : String!, $subtitleLanguage : String, $year : Int!,
                 $lengthInMinutes : Int!, $posterSrc : String)
                {
                  editMovie(input : {id: $id,title : $title, description : $description,
                  genre : $genre, director : $director, language : $language, subtitleLanguage : $subtitleLanguage, 
                  year : $year, lengthInMinutes : $lengthInMinutes, posterSrc : $posterSrc})
                  {
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
                } ";

            var variables = new
            {
                id = movie.Id,
                description = movie.Description,
                genre = movie.Genre,
                director = movie.Director,
                language = movie.Language,
                subtitleLanguage = movie.SubtitleLanguage,
                year = movie.Year,
                lengthInMinutes = movie.LengthInMinutes,
                posterSrc = movie.PosterSrc
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = new GraphQLResponse<EditMovieRoot>();
            
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<EditMovieRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            // Console.WriteLine(graphQLResponse.Data.editMovie.Director);

            return graphQLResponse.Data.editMovie;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            // Movie toRemove = Movies.FirstOrDefault(m => m.Id == movie.Id);
            // if (toRemove == null) return false;
            // Movies.Remove(movie);
            // return true;
            
            string query = @"mutation($id : Int!) 
                    {
                      deleteMovie (id : $id)
                    }";

            var variables = new
            {
                id = id
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = new GraphQLResponse<DeleteMovieRoot>();
            
            try
            {
                graphQLResponse = await graphQlClient.SendMutationAsync<DeleteMovieRoot>(graphQLRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return graphQLResponse.Data.deleteMovie;
        }

        public async Task<Movie> GetMovie(int movieId)
        {
            string query = @"query ($id : Int!) 
                    {
                      movie (id : $id) 
                      {
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
                    }";
            
            var variables = new
            {
                id = movieId
            };
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query,variables);
            var graphQLResponse = await graphQlClient.SendQueryAsync<MovieRoot>(graphQLRequest);

            return graphQLResponse.Data.movie;
            // return Movies.FirstOrDefault(m => m.Id == id);
        }

        public async Task<IList<Movie>> GetAllMovies()
        {
            string query = @"query
                    {
                      movies {
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
                    }";
            
            var graphQLRequest = GraphQLUtility.MakeGraphQLRequest(query);
            var graphQLResponse = await graphQlClient.SendQueryAsync<MoviesRoot>(graphQLRequest);

            return graphQLResponse.Data.movies;
            // return Movies;
        }

        private void Seed()
        {
            Movie[] movieArray =
            {
                new Movie
                {
                    Id = 1,
                    Description =
                        "The 1930s. A bankrupt director and a starving actress travel to the mysterious Skull Island to shoot a movie of their life, as New York is in a great crisis. ",
                    Director = "Peter Jackson",
                    Genre = "Adventure, Melodrama, Fantasy",
                    Language = "English",
                    LengthInMinutes = 200,
                    Year = 2005,
                    Title = "King Kong",
                    PosterSrc = "/images/king_kong.jpg",
                    // Cast = new List<Actor>(),
                },
                new Movie
                {
                    Id = 2,
                    Title = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    Genre = "Drama / Comedy",
                    Year = 2004,
                    Description =
                        "The life story of Forrest, a boy with a low IQ with paralysis, who becomes a billionaire and a hero of the Vietnam War.",
                    Language = "English",
                    LengthInMinutes = 186,
                    PosterSrc = "/images/forrest_gump.jpg",
                    // Cast = new List<Actor>(),
                },
                new Movie
                {
                    Id = 3,
                    Title = "Shawshank Redemption",
                    // Cast = new List<Actor>(),
                    Description =
                        "Adaptation of a Stephen King short story. A banker who is wrongly sentenced to life imprisonment, tries to survive in a brutal prison world. ",
                    Director = "Frank Darabont",
                    Genre = "Drama",
                    Language = "English",
                    LengthInMinutes = 110,
                    Year = 1994,
                    PosterSrc = "/images/shawshank.jpg"
                },
                new Movie
                {
                    Id = 4,
                    Title = "Leon",
                    // Cast = new List<Actor>(),
                    Description =
                        "A paid murderer saves a 12-year-old girl whose family has been killed by corrupt policemen. ",
                    Genre = "Drama, Criminal Story",
                    Director = "Luc Besson",
                    Language = "English",
                    LengthInMinutes = 110,
                    Year = 1994,
                    PosterSrc = "/images/leon.jpg"
                },
                new Movie
                {
                    Id=5,
                    // Cast = new List<Actor>(),
                    Description =
                        "To get his home back, an ugly ogre with a talkative donkey sets off to free the beautiful princess.",
                    Title = "Shrek",
                    Director = "Andrew Adamson / Vicky Jenson",
                    Genre = "Comedy, Animation, Family",
                    Language = "English, Danish",
                    LengthInMinutes = 90,
                    Year = 2001,
                    PosterSrc = "/images/shrek.jpg"
                },
                new Movie
                {
                    Id = 6,
                    // Cast = new List<Actor>(),
                    Description =
                        "Computer hacker Neo learns from mysterious rebels that the world he lives in is just an image sent to his brain by robots.",
                    Director = "Lilly Wachowski, Lana Wachowski",
                    Genre = "Action, Sci-Fi",
                    Language = "English",
                    LengthInMinutes = 136,
                    Title = "The Matrix",
                    Year = 1999,
                    PosterSrc = "/images/matrix.jpg"
                }
            };
            Movies = movieArray.ToList();
        }
    }
}