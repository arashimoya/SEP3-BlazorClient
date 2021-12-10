using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public class PlayRequest : IPlayRequest
    {
        private IList<Play> Plays;

        public PlayRequest()
        {
            Plays = new List<Play>();
            if (!Plays.Any()) Seed();
        }
        public async Task<bool> CreatePlay(Play play) {
            Plays.Add(play);
            return true;
        }

        public async Task<bool> EditPlay(Play play)
        {
            Play toUpdate = Plays.FirstOrDefault(p => p.Id == play.Id);
            if (toUpdate == null) return false;
            toUpdate.Date = play.Date;
            toUpdate.Hall = play.Hall;
            toUpdate.Movie = play.Movie;
            toUpdate.Tickets = play.Tickets;
            toUpdate.TimeInMinutes = play.Movie.LengthInMinutes;
            return true;
        }

        public async Task<bool> DeletePlay(Play play)
        {
            Play toRemove = Plays.FirstOrDefault(p => p.Id == play.Id);
            if (toRemove == null) return false;
            Plays.Remove(toRemove);
            return true;
        }

        public async Task<Play> Get(int id)
        {
            return Plays.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IList<Play>> GetAllPlays()
        {
            return Plays;
        }
        
        private void Seed()
        {
            Play[] playArray =
            {
                new Play
                {
                    Movie = new Movie
                    {
                        Description = "The 1930s. A bankrupt director and a starving actress travel to the mysterious Skull Island to shoot a movie of their life, as New York is in a great crisis. ",
                        Director = "Peter Jackson",
                        Genre = "Adventure, Melodrama, Fantasy",
                        Language = "English",
                        LengthInMinutes = 200,
                        Year = 2005,
                        Title = "King Kong",
                        PosterSrc = "/images/king_kong.jpg",
                    },
                    Date = DateTime.Now,
                    Hall = new Hall(1),
                    Tickets = new List<Ticket>
                    {
                        
                    },
                    TimeInMinutes = 200,
                },
                new Play
                {
                    Date = DateTime.Now,
                    Hall = new Hall(2),
                    Movie = new Movie
                    {
                        Title = "Forrest Gump",
                        Director = "Robert Zemeckis",
                        Genre = "Drama / Comedy",
                        Year = 2004,
                        Description = "The life story of Forrest, a boy with a low IQ with paralysis, who becomes a billionaire and a hero of the Vietnam War.",
                        Language = "English",
                        LengthInMinutes = 186,
                        PosterSrc = "/images/forrest_gump.jpg",
                    },
                    Tickets = new List<Ticket>(),
                    TimeInMinutes = 186,
                },
                new Play
                {
                    Date = DateTime.Now,
                    Hall = new Hall(3),
                    Movie = new Movie
                    {
                        Description = "To get his home back, an ugly ogre with a talkative donkey sets off to free the beautiful princess.",
                        Title = "Shrek",
                        Director = "Andrew Adamson / Vicky Jenson",
                        Genre = "Comedy, Animation, Family",
                        Language = "English, Danish",
                        LengthInMinutes = 90,
                        Year = 2001,
                        PosterSrc = "/images/shrek.jpg",
                    },
                    Tickets = new List<Ticket>(),
                    TimeInMinutes = 90,
                },
                new Play
                {
                    Date = DateTime.Now,
                    Hall = new Hall(1),
                    Movie = new Movie
                    {
                        //Id = 3,
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
                    Tickets = new List<Ticket>(),
                    TimeInMinutes = 110,
                },
            };
            Plays = playArray.ToList();

        }
    }
}