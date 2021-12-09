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
            return ClientFactory.GetClient().EditEmployee(employee);
        }

        public Task<bool> DeleteEmployee(int employeeId)
        {
           // return ClientFactory.GetClient().DeleteEmployee(employeeId);
           throw new System.NotImplementedException();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await ClientFactory.GetClient().GetEmployee(employeeId);
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            throw new System.NotImplementedException();
        }
    }
}