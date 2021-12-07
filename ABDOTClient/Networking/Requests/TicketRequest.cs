using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public class TicketRequest : ITicketRequest
    {
        private IList<Ticket> Tickets;

        public TicketRequest()
        {
            Tickets = new List<Ticket>();
        }
        public async Task<bool> Create(Ticket ticket) {
            Tickets.Add(ticket);
            return true;
        }

        public async Task<bool> Edit(Ticket ticket)
        {
            Ticket toUpdate = Tickets.FirstOrDefault(t => t.Id == ticket.Id);
            if (toUpdate == null) return false;
            toUpdate.Employee = ticket.Employee;
            toUpdate.Play = ticket.Play;
            toUpdate.User = ticket.User;
            return true;
        }

        public async Task<bool> Delete(Ticket ticket)
        {
            Ticket toRemove = Tickets.FirstOrDefault(t => t.Id == ticket.Id);
            if (toRemove == null) return false;
            Tickets.Remove(ticket);
            return true;
        }

        public async Task<Ticket> GetTicket(int Ticketid)
        {
            return Tickets.FirstOrDefault(t => t.Id == Ticketid);
        }

        public async Task<IList<Ticket>> GetAllTickets()
        {
            return Tickets;
        }
    }
}