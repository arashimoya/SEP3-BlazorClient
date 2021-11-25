using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABDOTClient.Networking.Requests {
    public class ProgramRequest : IProgramRequest {
        public Task<bool> CreateProgram(Program program) {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditProgram(Program program) {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProgram(Program program) {
            throw new System.NotImplementedException();
        }

        public Task<Program> GetProgram(int id) {
            throw new System.NotImplementedException();
        }

        public Task<List<Program>> GetAllPrograms() {
            throw new System.NotImplementedException();
        }
    }
}