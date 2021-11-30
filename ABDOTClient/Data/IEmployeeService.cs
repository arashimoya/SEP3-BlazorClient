using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);

        Task<bool> EditEmployee(Employee employee);

        Task<bool> DeleteEmployee(int employeeId);

        Task<Employee> GetEmployee(int employeeId);

        Task<List<Employee>> GetAllEmployees();
    }
}