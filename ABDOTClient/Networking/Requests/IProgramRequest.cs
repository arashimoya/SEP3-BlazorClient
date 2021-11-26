using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABDOTClient.Networking.Requests {
    public interface IProgramRequest {
        Task<bool> CreateProgram(Program program);

        Task<bool> EditProgram(Program program);

        Task<bool> DeleteProgram(Program program);

        Task<Program> GetProgram(int id);

        Task<List<Program>> GetAllPrograms();
    }
}