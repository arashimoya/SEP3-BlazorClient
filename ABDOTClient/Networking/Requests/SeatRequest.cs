using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public class SeatRequest : ISeatRequest {
        public Task<bool> CreateSeat(Seat seat) {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditSeat(Seat seat) {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteSeat(Seat seat) {
            throw new System.NotImplementedException();
        }

        public Task<Seat> GetSeat(int id) {
            throw new System.NotImplementedException();
        }

        public Task<List<Seat>> GetAllSeats() {
            throw new System.NotImplementedException();
        }
    }
}