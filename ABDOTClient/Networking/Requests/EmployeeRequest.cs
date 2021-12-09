using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Data;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public class EmployeeRequest : IEmployeeRequest
    {
        private IList<Employee> Employees;

        public EmployeeRequest()
        {
            Employees = new List<Employee>();
            if (!Employees.Any()) Seed();
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            Employees.Add(employee);
            return true;
        }

        public async Task<bool> EditEmployee(Employee employee)
        {
            Employee toUpdate = Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (toUpdate == null) return false;
            toUpdate.Birthday = employee.Birthday;
            toUpdate.City = employee.City;
            toUpdate.Branch = employee.Branch;
            toUpdate.Country = employee.Country;
            toUpdate.Postcode = employee.Postcode;
            toUpdate.Role = employee.Role;
            toUpdate.Street = employee.Street;
            toUpdate.Email = employee.Email;
            toUpdate.Password = employee.Password;
            toUpdate.FirstName = employee.FirstName;
            toUpdate.LastName = employee.LastName;
            return true;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            Employee toRemove = Employees.FirstOrDefault(e => e.Id == employeeId);
            if (toRemove == null) return false;
            Employees.Remove(toRemove);
            return true;

        }

        public async Task<Employee> GetEmployee(int Employeeid)
        {
            return Employees.FirstOrDefault(e => e.Id == Employeeid);
        }

        public async Task<IList<Employee>> GetAllEmployees()
        {
            return Employees;
        }

        private void Seed()
        {
            Employee[] employeesArray =
            {
                new Employee()
                {
                    Id = 1,
                    FirstName = "Christian",
                    LastName = "Dam",
                    Email = "ChristianLDam@jourrapide.com",
                    Password = "dam123",
                    Birthday = new DateTime(1994, 9, 21),
                    CPR = "210994-4869",
                },
                new Employee()
                {
                    Id = 2,
                    FirstName = "Mille",
                    LastName = "Bertensen",
                    Email = "MilleABertelsen@dayrep.com",
                    Password = "bertensen123",
                    Birthday = new DateTime(1978, 11, 28),
                    CPR = "281178-4756"
                }
            };
            Employees = employeesArray.ToList();
        }
    }
}