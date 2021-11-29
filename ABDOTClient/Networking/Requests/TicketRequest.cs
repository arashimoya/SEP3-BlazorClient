using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public class TicketRequest : ITicketRequest
    {
        public Task<bool> Create(Ticket ticket) {
            throw new System.NotImplementedException();
        }

        public Task<bool> Edit(Ticket ticket) {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Ticket ticket) {
            throw new System.NotImplementedException();
        }

        public Task<Ticket> GetTicket(int Ticketid) {
            throw new System.NotImplementedException();
        }

        public Task<List<Ticket>> GetAllTicktets() {
            throw new System.NotImplementedException();
        }
    }
}