using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public class PlayRequest : IPlayRequest{
        public Task<bool> CreatePlay(Play play) {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditPlay(Play play) {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeletePlay(Play play) {
            throw new System.NotImplementedException();
        }

        public Task<Play> Get(int id) {
            throw new System.NotImplementedException();
        }

        public Task<List<Play>> GetAllPlays() {
            throw new System.NotImplementedException();
        }
    }
}