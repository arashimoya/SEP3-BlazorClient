using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface ITicketService
    {
        Task<IList<Ticket>> GetAllAsync();
        Task<bool> AddTicketAsync(Ticket ticket);
        Task<bool> UpdateTicketAsync(Ticket ticket);
        Task<bool> RemoveTicketAsync(Ticket ticket);
        Task<Ticket> GetAsync(int ticketId);
    }
}