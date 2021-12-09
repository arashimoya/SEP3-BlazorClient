using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class HallCloudService : IHallService
    {
        public Task<bool> CreateHall(Hall hall)
        {
            return ClientFactory.GetClient().AddHall(hall);
        }

        public Task<bool> EditHall(Hall hall)
        {
            return ClientFactory.GetClient().EditHall(hall);
        }

        public Task<bool> DeleteHall(int branchId)
        {
          //  return ClientFactory.GetClient().DeleteHall(branchId);
          throw new System.NotImplementedException();
        }

        public Task<Hall> Get(int hallId)
        {
            return ClientFactory.GetClient().GetHall(hallId);
        }

        public Task<IList<Hall>> GetAllHalls()
        {
            return ClientFactory.GetClient().GetAllHalls();
        }
    }
}