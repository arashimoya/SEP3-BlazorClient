using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IHallService
    {
        Task<bool> CreateHall(Hall hall);

        Task<bool> EditHall(Hall hall);

        Task<bool> DeleteHall(Hall hall);

        Task<Hall> GetHall(int Hallid);

        Task<List<Hall>> GetAllHalls();
    }
}