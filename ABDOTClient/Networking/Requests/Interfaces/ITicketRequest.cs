using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public interface ITicketRequest
    {
        Task<Ticket> CreateTicketAsync(Ticket ticket);

        Task<Ticket> EditTicketAsync(Ticket ticket);

        Task<bool> DeleteTicketAsync(int ticketId);

        Task<Ticket> GetTicketAsync(int ticketId);

        Task<IList<Ticket>> GetAllTicketsAsync();
    }
}