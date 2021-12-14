using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public interface IEmployeeRequest
    {
        Task<Employee> CreateEmployee(Employee employee);

        Task<Employee> EditEmployee(Employee employee);

        Task<bool> DeleteEmployee(int employeeId);

        Task<Employee> GetEmployee(int employeeId);

        Task<IList<Employee>> GetAllEmployees();
        
        Task<Employee> LoginEmployee(Employee employee);
    }
}