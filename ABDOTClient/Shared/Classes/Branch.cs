using System.Collections.Generic;

namespace ABDOTClient.Shared.Classes
{
    public class Branch
    {
        private int id { set; get; }
        private List<Hall> Halls;
        private Program Program { set; get; }

        public Branch(int id, Program Program)
        {
            this.id = id;
            Halls = new List<Hall>();
            this.Program = Program;
        }
    }
    
}