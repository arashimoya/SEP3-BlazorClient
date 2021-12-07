using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public interface IPlayRequest {
        Task<bool> CreatePlay(Play play);

        Task<bool> EditPlay(Play play);

        Task<bool> DeletePlay(Play play);

        Task<Play> Get(int id);

        Task<IList<Play>> GetAllPlays();
    }
}