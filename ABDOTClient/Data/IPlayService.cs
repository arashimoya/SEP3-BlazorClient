using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IPlayService
    {
        Task<Play> AddPlayAsync(Play play);
        Task<Play> UpdatePlayAsync(Play play);
        Task<bool> RemovePlayAsync(int playId);
        Task<Play> GetAsync(int id);
        Task<IList<Play>> GetAllAsync();
    }
}