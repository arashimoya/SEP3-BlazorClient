using System;

namespace ABDOTClient.Model
{
    public class Play
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public DateTime DateTime { get; set; }
        public Branch Branch { get; set; }
        public Hall Hall { get; set; }
    }
}