using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class TicketCloudService : ITicketService
    {
        public async Task<IList<Ticket>> GetAllAsync()
        {
            return await ClientFactory.GetClient().GetAllTickets();
        }

        public async Task<bool> AddTicketAsync(Ticket ticket)
        {
            return await ClientFactory.GetClient().AddTicket(ticket);
        }

        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            return await ClientFactory.GetClient().EditTicket(ticket);
        }

        public async Task<bool> RemoveTicketAsync(Ticket ticket)
        {
            return await ClientFactory.GetClient().DeleteTicket(ticket);
        }

        public async Task<Ticket> GetAsync(int ticketId)
        {
            return await ClientFactory.GetClient().GetTicket(ticketId);
        }
    }
}