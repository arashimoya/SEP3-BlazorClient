using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public interface IEmployeeRequest
    {
        Task<bool> CreateEmployee(Employee employee);

        Task<bool> EditEmployee(Employee employee);

        Task<bool> DeleteEmployee(Employee employee);

        Task<Employee> GetEmployee(int Employeeid);

        Task<IList<Employee>> GetAllEmployees();
    }
}