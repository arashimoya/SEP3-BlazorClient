using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class PlayCloudService : IPlayService
    {
        public async Task<bool> AddPlayAsync(Play play)
        {
            play.TimeInMinutes = play.Movie.LengthInMinutes;
            return await ClientFactory.GetClient().AddPlay(play);
        }

        public async Task<bool> UpdatePlayAsync(Play play)
        {
            return await ClientFactory.GetClient().EditPlay(play);
        }

        public async Task<bool> RemovePlayAsync(Play play)
        {
            return await ClientFactory.GetClient().DeletePlay(play);
        }

        public async Task<Play> GetAsync(int id)
        {
            return await ClientFactory.GetClient().GetPlay(id);
        }

        public async Task<IList<Play>> GetAllAsync()
        {
            return await ClientFactory.GetClient().GetAllPlays();
        }
    }
}