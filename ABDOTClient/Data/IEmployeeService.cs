using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(Employee employee);

        Task<Employee> EditEmployee(Employee employee);

        Task<bool> DeleteEmployee(int employeeId);

        Task<Employee> GetEmployee(int employeeId);

        Task<IList<Employee>> GetAllEmployees();
    }
}