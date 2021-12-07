using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public class HallRequest : IHallRequest
    {
        private IList<Hall> Halls;

        public HallRequest()
        {
            Halls = new List<Hall>();
        }
        public async Task<bool> CreateHall(Hall hall) {
            Halls.Add(hall);
            return true;
        }

        public async Task<bool> EditHall(Hall hall)
        {
            Hall toUpdate = Halls.FirstOrDefault(h => h.Id == hall.Id);
            if (toUpdate == null) return false;
            if (toUpdate.HallSize != hall.HallSize)
            {
                toUpdate = new Hall(hall.HallSize);
            }
            toUpdate.Branch = hall.Branch;
            toUpdate.Programme = hall.Programme;
            return true;
        }

        public async Task<bool> DeleteHall(Hall hall)
        {
            Hall toRemove = Halls.FirstOrDefault(h => h.Id == hall.Id);
            if (toRemove == null) return false;
            Halls.Remove(hall);
            return true;
        }

        public async Task<Hall> GetHall(int hallId)
        {
            return Halls.FirstOrDefault(h => h.Id == hallId);
        }

        public async Task<IList<Hall>> GetAllHalls()
        {
            return Halls;
        }
    }
}