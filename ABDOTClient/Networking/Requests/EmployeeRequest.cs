using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Data;
using ABDOTClient.Factories;
using ABDOTClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace ABDOTClient.Networking.Requests {
    public class EmployeeRequest : IEmployeeRequest {
        private class EmployeesRoot {
            public List<Employee> Employees { get; set; }

            public EmployeesRoot() {
                Employees = new List<Employee>();
            }
        }

        private class EmployeeRoot {
            public Employee Employee { get; set; }
        }

        private class DeleteRoot {
            public bool deleteEmployee { get; set; }
        }


        private class CreateEmployeeRoot {
            public Employee createEmployee { get; set; }
        }

        private class EditEmployeeRoot {
            public Employee editEmployee { get; set; }
        }


        private IList<Employee> Employees;
        private GraphQLHttpClient graphQlClient;

        public EmployeeRequest() {
            graphQlClient = new GraphQLHttpClient("https://abdot-middleware.herokuapp.com/graphql",
                new NewtonsoftJsonSerializer());
            Employees = new List<Employee>();
        }

        public async Task<Employee> CreateEmployee(Employee employee) {
            //TODO FIX
//             string query = @"
//
//                             
//                             ";
//             
//             
//             var variables = new {
//                 birthday = employee.Birthday,
//                 city = employee.City,
//                 branch = employee.Branch,
//                 country = employee.Country,
//                 postcode = employee.Postcode,
//                 role = employee.Role,
//                 street = employee.Street,
//                 email = employee.Email,
//                 password = employee.Password,
//                 firstName = employee.FirstName,
//                 lastName = employee.LastName
//             };
            return null;
        }

        public async Task<Employee> EditEmployee(Employee employee) {
            //TODO FIX
            // string query
            //
            //
            // var variables = new {
            //     birthday = employee.Birthday,
            //     city = employee.City,
            //     branch = employee.Branch,
            //     country = employee.Country,
            //     postcode = employee.Postcode,
            //     role = employee.Role,
            //     street = employee.Street,
            //     email = employee.Email,
            //     password = employee.Password,
            //     firstName = employee.FirstName,
            //     lastName = employee.LastName
            // };
            return null;
        }

        public async Task<bool> DeleteEmployee(int employeeId) {
            string query = @"
                mutation($id:Int!){
                  deleteEmployee(id:$id)
                }
            ";
            var variables = new {
                id = employeeId
            };

            var graphQlRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            var graphQlResponse = new GraphQLResponse<DeleteRoot>();
            try {
                graphQlResponse = await graphQlClient.SendMutationAsync<DeleteRoot>(graphQlRequest);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine(graphQlResponse.Data.deleteEmployee);
            return graphQlResponse.Data.deleteEmployee;
        }

        public async Task<Employee> GetEmployee(int employeeId) {
            string query = @"query($id: Int!) {employee(id:$id){
                              role,
                              firstName,
                              lastName,
                              email,
                              password,
                              cPR,
                              street,
                              city,
                              postcode,
                              country,
                              birthDate,
                              branch{
                                  id
                              }
                              id
                            }}";

            var variables = new {
                id = employeeId
            };


            var graphQlRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            GraphQLResponse<EmployeeRoot> graphQlResponse;
            try {
                graphQlResponse = await graphQlClient.SendQueryAsync<EmployeeRoot>(graphQlRequest);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine(graphQlResponse.Data.Employee.FirstName);
            return graphQlResponse.Data.Employee;
        }

        public async Task<IList<Employee>> GetAllEmployees() {
            string query = @"query {employees{
                              role,
                              firstName,
                              lastName,
                              email,
                              password,
                              cPR,
                              street,
                              city,
                              postcode,
                              country,
                              birthDate,
                              branch{
                                  id
                              }
                              id
                            }}";

            var graphQlRequest = GraphQLUtility.MakeGraphQLRequest(query);
            GraphQLResponse<EmployeesRoot> graphQlResponse;
            try {
                graphQlResponse = await graphQlClient.SendQueryAsync<EmployeesRoot>(graphQlRequest);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine(graphQlResponse.Data.Employees.Count);
            return graphQlResponse.Data.Employees;
        }
        
    }
}