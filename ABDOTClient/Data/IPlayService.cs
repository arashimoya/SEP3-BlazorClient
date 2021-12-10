using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IPlayService
    {
        Task<bool> AddPlayAsync(Play play);
        Task<bool> UpdatePlayAsync(Play play);
        Task<bool> RemovePlayAsync(Play play);
        Task<Play> GetAsync(int id);
        Task<IList<Play>> GetAllAsync();
    }
}