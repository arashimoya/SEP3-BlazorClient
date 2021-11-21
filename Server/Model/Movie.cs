using System.Collections.Generic;

namespace Server.Model
{
    public class Movie
    {
        public Movie()
        {
            Cast = new List<Actor>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public IList<Actor> Cast { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public string PosterSrc { get; set; }
    }
}