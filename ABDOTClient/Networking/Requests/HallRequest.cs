using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class HallRequest : IHallRequest

    {
    public Task<bool> CreateHall(Hall hall) {
        throw new System.NotImplementedException();
    }

    public Task<bool> EditHall(Hall hall) {
        throw new System.NotImplementedException();
    }

    public Task<bool> DeleteHall(Hall hall) {
        throw new System.NotImplementedException();
    }

    public Task<Hall> GetHall(int Hallid) {
        throw new System.NotImplementedException();
    }

    public Task<List<Hall>> GetAllHalls() {
        throw new System.NotImplementedException();
    }
    }
}