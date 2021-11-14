using System.Collections.Generic;

namespace ABDOTClient.Model
{
    public class Movie
    {
        public Movie()
        {
            Cast = new List<string>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public IList<string> Cast { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public string PosterSrc { get; set; }
    }
}