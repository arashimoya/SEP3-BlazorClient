using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IHallService
    {
        Task<bool> CreateHall(Hall hall);
     
        Task<bool> EditHall(Hall hall);
     
        Task<bool> DeleteHall(int branchId);
        
        Task<Hall> Get(int hallId);

        Task<IList<Hall>> GetAllHalls();
    }
}