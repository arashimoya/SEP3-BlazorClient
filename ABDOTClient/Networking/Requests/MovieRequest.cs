using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking {
    public class MovieRequest : IMovieRequest {

        private static readonly HttpClient httpClient = new HttpClient();
        private IList<Movie> Movies;

        public MovieRequest()
        {
            Movies = new List<Movie>();
            if (!Movies.Any()) Seed();
        }

        public async Task<bool> CreateMovie(Movie movie) {
            Movies.Add(movie);
            return true;
        }

        public async Task<bool> EditMovie(Movie movie)
        {
            Movie toUpdate = Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (toUpdate == null) return false;
            toUpdate.Description = movie.Description;
            toUpdate.Director = movie.Director;
            toUpdate.Genre = movie.Genre;
            toUpdate.Language = movie.Language;
            toUpdate.Title = movie.Title;
            toUpdate.Year = movie.Year;
            toUpdate.SubtitleLanguage = movie.SubtitleLanguage;
            toUpdate.LengthInMinutes = movie.LengthInMinutes;
            return true;
        }

        public async Task<bool> DeleteMovie(Movie movie)
        {
            Movie toRemove = Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (toRemove == null) return false;
            Movies.Remove(movie);
            return true;
        }

        public async Task<Movie> GetMovie(int id)
        {
            return Movies.FirstOrDefault(m => m.Id == id);
        }

        public async Task<IList<Movie>> GetAllMovies()
        {
            return Movies;
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