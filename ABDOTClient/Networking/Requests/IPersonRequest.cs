using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public interface IPersonRequest {
        Task<bool> CreatePerson(Person person);

        Task<bool> EditPerson(Person person);

        Task<bool> DeletePerson(Person person);

        Task<Person> GetPerson(int id);

        Task<List<Person>> GetAllPerson();
    }
}