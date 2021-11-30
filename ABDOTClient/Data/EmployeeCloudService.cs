using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class EmployeeCloudService : IEmployeeService
    {
        public Task<bool> CreateEmployee(Employee employee)
        {
            return ClientFactory.GetClient().AddEmployee(employee);
        }

        public Task<bool> EditEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteEmployee(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            throw new System.NotImplementedException();
        }
    }
}