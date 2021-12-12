using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data {
    public class HallCloudService : IHallService{
        public async Task<Hall> CreateHall(Hall hall) {
            return await ClientFactory.GetClient().AddHall(hall);
        }

        public async Task<Hall> EditHall(Hall hall) {
            return await ClientFactory.GetClient().EditHall(hall);
        }

        public async Task<bool> DeleteHall(int hallId) {
            return await ClientFactory.GetClient().DeleteHall(hallId);
        }

        public async Task<Hall> GetHall(int hallId) {
            return await ClientFactory.GetClient().GetHall(hallId);
        }

        public async Task<IList<Hall>> GetAllHalls() {
            return await ClientFactory.GetClient().GetAllHalls();
        }
    }
}