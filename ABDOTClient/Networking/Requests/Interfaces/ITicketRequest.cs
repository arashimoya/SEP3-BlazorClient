using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public interface ITicketRequest
    {
        Task<Ticket> CreateTicket(Ticket ticket);

        Task<Ticket> EditTicket(Ticket ticket);

        Task<bool> DeleteTicket(int ticketId);

        Task<Ticket> GetTicket(int ticketId);

        Task<IList<Ticket>> GetAllTickets();
    }
}