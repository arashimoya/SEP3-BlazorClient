using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public class OperatorRequest: IOperatorRequest {
        public Task<bool> CreatePerson(Person person) {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditPerson(Person person) {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeletePerson(Person person) {
            throw new System.NotImplementedException();
        }

        public Task<Person> GetPerson(int id) {
            throw new System.NotImplementedException();
        }

        public Task<List<Person>> GetAllPersons() {
            throw new System.NotImplementedException();
        }
    }
}