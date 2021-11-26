using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public interface ISeatRequest {
        Task<bool> CreateSeat(Seat seat);

        Task<bool> EditSeat(Seat seat);

        Task<bool> DeleteSeat(Seat seat);

        Task<Seat> GetSeat(int id);

        Task<List<Seat>> GetAllSeats();
    }
}