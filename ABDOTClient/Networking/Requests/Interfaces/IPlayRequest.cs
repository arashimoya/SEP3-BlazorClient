using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public interface IPlayRequest {
        Task<Play> CreatePlay(Play play);

        Task<Play> EditPlay(Play play);

        Task<bool> DeletePlay(int id);

        Task<Play> GetPlay(int id);

        Task<IList<Play>> GetAllPlays();
    }
}