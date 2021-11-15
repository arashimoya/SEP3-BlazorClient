using System.Collections.Generic;

namespace ABDOTClient.Shared.Classes
{
    public class Hall
    {
        private int id { set; get; }
        private List<Seat> Seats;

        public Hall(int id)
        {
            this.id = id;
            Seats = new List<Seat>();
        }
    }
}