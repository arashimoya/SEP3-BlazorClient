using System.Collections.Generic;

namespace ABDOTClient.Model
{
    public class Branch
    {
        public int Id { get; set; }
        public string City { get; set; }
        public IList<Hall> Halls { get; set; }
    }
}