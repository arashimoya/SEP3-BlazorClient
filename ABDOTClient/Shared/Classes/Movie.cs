using System.Collections.Generic;

namespace ABDOTClient.Shared.Classes
{
    public class Movie
    {
        private int id { set; get; }
        private string Title { set; get; }
        private string Description { set; get; }
        private string Genre { set; get; }
        private List<string> Cast { set; get; }
        private int Length { set; get; }
        private string Language { set; get; }
        private int Year { set; get; }

        public Movie(int id, string Title, string Description, string Genre, List<string> Cast, int Length,
            string Language, int Year)
        {
            this.id = id;
            this.Title = Title;
            this.Description = Description;
            this.Genre = Genre;
            this.Cast = Cast;
            this.Length = Length;
            this.Language = Language;
            this.Year = Year;
        }

    }
}