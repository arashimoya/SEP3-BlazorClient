using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public interface IHallRequest
    {
        Task<bool> CreateHall(Hall hall);

        Task<bool> EditHall(Hall hall);

        Task<bool> DeleteHall(int hallId);

        Task<Hall> GetHall(int hallId);

        Task<IList<Hall>> GetAllHalls();
    }
}