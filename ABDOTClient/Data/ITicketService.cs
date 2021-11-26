using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface ITicketService
    {
        Task<bool> Create(Ticket ticket);

        Task<bool> Edit(Ticket ticket);

        Task<bool> Delete(Ticket ticket);

        Task<Ticket> GetTicket(int Ticketid);

        Task<List<Ticket>> GetAllTicktets();
    }
}