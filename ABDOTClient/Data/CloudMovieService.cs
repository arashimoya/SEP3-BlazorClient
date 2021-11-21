using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;
using ABDOTClient.Networking;
using ABDOTClient.Persistence;

namespace ABDOTClient.Data
{
    public class CloudMovieService : IMovieService
    {
        private IList<Movie> movies;
        private ServerContext ServerContext;
        private Client client;

        public CloudMovieService()
        {
            ServerContext = new ServerContext();
            client = new Client();
        }
        public async Task<IList<Movie>> GetAllAsync()
        {
            return movies;
        }

        public async Task<bool> AddMovieAsync(Movie movie)
        {
           return ClientFactory.GetClient().AddMovie(movie);
        }

        public Task UpdateMovieAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveMovieAsync(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> GetAsync(int id)
        {
            Movie toReturn = movies.FirstOrDefault(m => m.Id == id);
            return toReturn;
        }
        
        private void Seed()
    {
        Movie[] movieArray =
        {
            new Movie
            {
                Id = 1,
                Description = "The 1930s. A bankrupt director and a starving actress travel to the mysterious Skull Island to shoot a movie of their life, as New York is in a great crisis. ",
                Director = "Peter Jackson",
                Genre = "Adventure, Melodrama, Fantasy",
                Language = "English",
                Length = 200,
                Year = 2005,
                Title = "King Kong",
                PosterSrc = "/images/king_kong.jpg",
                Cast = new List<Actor>(),

            },
            new Movie
            {
                Id = 2,
                Title = "Forrest Gump",
                Director = "Robert Zemeckis",
                Genre = "Drama / Comedy",
                Year = 2004,
                Cast = new List<Actor>(),
                Description = "The life story of Forrest, a boy with a low IQ with paralysis, who becomes a billionaire and a hero of the Vietnam War.",
                Language = "English",
                Length = 186,
                PosterSrc = "/images/forrest_gump.jpg"
            },
            new Movie
            {
                Id = 3,
                Title = "Shawshank Redemption",
                Cast = new List<Actor>(),
                Description = "Adaptation of a Stephen King short story. A banker who is wrongly sentenced to life imprisonment, tries to survive in a brutal prison world. ",
                Director = "Frank Darabont",
                Genre = "Drama",
                Language = "English",
                Length = 110,
                Year = 1994,
                PosterSrc = "/images/shawshank.jpg"
            },
            new Movie
            {
                Id = 4,
                Title = "Leon",
                Cast = new List<Actor>(),
                Description = "A paid murderer saves a 12-year-old girl whose family has been killed by corrupt policemen. ",
                Genre = "Drama, Criminal Story",
                Director = "Luc Besson",
                Language = "English",
                Length = 110,
                Year= 1994,
                PosterSrc = "/images/leon.jpg"
            },
            new Movie
            {
                Id=5,
                Cast = new List<Actor>(),
                Description = "To get his home back, an ugly ogre with a talkative donkey sets off to free the beautiful princess.",
                Title = "Shrek",
                Director = "Andrew Adamson / Vicky Jenson",
                Genre = "Comedy, Animation, Family",
                Language = "English, Danish",
                Length = 90,
                Year = 2001,
                PosterSrc = "/images/shrek.jpg"
            },
            new Movie
            {
                Id = 6,
                Cast = new List<Actor>(),
                Description = "Computer hacker Neo learns from mysterious rebels that the world he lives in is just an image sent to his brain by robots.",
                Director = "Lilly Wachowski, Lana Wachowski",
                Genre = "Action, Sci-Fi",
                Language = "English",
                Length = 136,
                Title = "The Matrix",
                Year = 1999,
                PosterSrc = "/images/matrix.jpg"
            }
        };
        movies = movieArray.ToList();
        movies[0].Cast.Add(new Actor("Naomi Watts"));
        movies[0].Cast.Add(new Actor("Jack Black"));
        movies[0].Cast.Add(new Actor("Adrien Brody"));
        movies[1].Cast.Add(new Actor("Tom Hanks"));
        movies[2].Cast.Add(new Actor("Morgan Freeman"));
        movies[2].Cast.Add(new Actor("Tim Robbins"));
        movies[3].Cast.Add(new Actor("Jean Reno"));
        movies[3].Cast.Add(new Actor("Gary Oldman"));
        movies[3].Cast.Add(new Actor("Natalie Portman"));
        movies[4].Cast.Add(new Actor("Mike Myers"));
        movies[4].Cast.Add(new Actor("Eddie Murphy"));
        movies[4].Cast.Add(new Actor("Cameron Diaz"));
        movies[5].Cast.Add(new Actor("Keanu Reeves"));
        movies[5].Cast.Add(new Actor("Carrie-Anne Moss"));
        movies[5].Cast.Add(new Actor("Laurence Fishburne"));
        

    }
    }
}