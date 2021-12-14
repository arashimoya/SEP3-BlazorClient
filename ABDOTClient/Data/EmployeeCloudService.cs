using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class EmployeeCloudService : IEmployeeService
    {
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await ClientFactory.GetClient().AddEmployee(employee);
        }

        public async Task<Employee> EditEmployee(Employee employee) {
            return await ClientFactory.GetClient().EditEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(int employeeId) {
            return await ClientFactory.GetClient().DeleteEmployee(employeeId);
        }

        public async Task<Employee> GetEmployee(int employeeId) {
            return await ClientFactory.GetClient().GetEmployee(employeeId);
        }

        public async Task<IList<Employee>> GetAllEmployees() {
            return await ClientFactory.GetClient().GetAllEmployees();
        }

        public async Task<Employee> LoginEmployee(string username, string password) {
            var employee = new Employee();
            employee.Email = username;
            employee.Password = password;
            var loggedEmployee = await ClientFactory.GetClient().LoginEmployee(employee);
            
            return loggedEmployee;
        }
    }
}