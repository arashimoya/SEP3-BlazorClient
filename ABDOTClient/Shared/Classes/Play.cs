using System;

namespace ABDOTClient.Shared.Classes
{
    public class Play
    {
        private Movie Movie { set; get; }
        private int id { set; get; }
        private DateTime Date { set; get; }
        private Hall Hall { set; get; }

        public Play(Movie Movie, int id, DateTime Date, Hall Hall)
        {
            this.Movie = Movie;
            this.id = id;
            this.Date = Date;
            this.Hall = Hall;
        }
    }
}