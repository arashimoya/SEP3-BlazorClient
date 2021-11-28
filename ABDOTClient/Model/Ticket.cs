using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABDOTClient.Model
{
    public class Ticket
    {
        public int Id { set; get; }
        public Play Play { set; get; }
        public User User { set; get; }
        public Employee Employee { set; get; }
        public Tuple<int, int> seat { get; set; }
    }
}