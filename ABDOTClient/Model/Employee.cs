using System;

namespace ABDOTClient.Model
{
    public class Employee : User
    {
        public int Role { get; set; }
        public string CPR { get; set; }
        public DateTime Birthday { get; set; }
    }
}