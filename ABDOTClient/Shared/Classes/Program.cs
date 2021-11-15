using System.Collections.Generic;

namespace ABDOTClient.Shared.Classes
{
    public class Program
    {
        private int id { set; get; }
        private List<Play> Plays;
        

        public Program(int id)
        {
            this.id = id;
            Plays = new List<Play>();
            
        }
    }
}