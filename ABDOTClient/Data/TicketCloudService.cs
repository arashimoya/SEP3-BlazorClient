using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class TicketCloudService : ITicketService
    {
        public Task<IList<Ticket>> GetAllTickets()
        {
            return ClientFactory.GetClient().GetAllTickets();
        }

        public Task<Ticket> AddTicket(Ticket ticket)
        {
            return ClientFactory.GetClient().AddTicket(ticket);
        }

        public Task<Ticket> EditTicket(Ticket ticket)
        {
            return ClientFactory.GetClient().EditTicket(ticket);
        }

        public Task<bool> DeleteTicket(int ticketId)
        {
            return ClientFactory.GetClient().DeleteTicket(ticketId);
        }

        public Task<Ticket> GetTicket(int ticketId)
        {
            return ClientFactory.GetClient().GetTicket(ticketId);
        }
    }
}