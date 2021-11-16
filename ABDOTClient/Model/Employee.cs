using System;

namespace ABDOTClient.Model
{
    public class Employee : Person
    {
        public string Role { get; set; }
        public string CPR { get; set; }
        public DateTime Birthday { get; set; }
    }
}