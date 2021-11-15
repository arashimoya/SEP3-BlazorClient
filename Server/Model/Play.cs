using System;

namespace Server.Model
{
    public class Play
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public DateTime DateTime { get; set; }
        public Server.Model.Hall Hall { get; set; }
    }
}