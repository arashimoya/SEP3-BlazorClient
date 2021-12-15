using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;
using ABDOTClient.Networking.Requests;


namespace ABDOTClient.Data
{
    public class PlayCloudService : IPlayService {
        private IHallService _hallService = new HallCloudService();
        private IBranchService _branchService = new BranchCloudService();
        public async Task<Play> AddPlayAsync(Play play)
        {
            return await ClientFactory.GetClient().AddPlay(play);
        }

        public async Task<Play> UpdatePlayAsync(Play play)
        {
            return await ClientFactory.GetClient().EditPlay(play);
        }

        public async Task<bool> RemovePlayAsync(int playId)
        {
            return await ClientFactory.GetClient().DeletePlay(playId);
        }

        public async Task<Play> GetAsync(int id)
        {
            Play play = await ClientFactory.GetClient().GetPlay(id);
            return play;
        }

        public async Task<IList<Play>> GetAllAsync()
        {
            IList<Play> plays = await ClientFactory.GetClient().GetAllPlays();

            return plays;
        }
    }
}