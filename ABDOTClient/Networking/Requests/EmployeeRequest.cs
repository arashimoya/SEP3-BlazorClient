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
            Console.WriteLine("we are here in employeeRequest.cs and thats the employee:" + employee.ToString());
            string query = @"
                    mutation ($email : String!, $firstName : String!, $lastName : String!, $password: String!
                    $role : Int!, $cpr: String!, $street: String!, $city: String!, $postcode: String!
                    $country : String!, $birthday : String!, $branchId : Int!) {
                      createEmployee (input: {email : $email, firstName : $firstName, lastName : $lastName
                      password : $password, role: $role, cpr : $cpr, street : $street, city : $city, postcode : $postcode
                      country : $country, birthday : $birthday, branchId: $branchId}) {
                    id,      
                    email,
                          firstName,
                          lastName,
                          password,
                          role,
                          cPR,
                          city,
                          street,
                          postcode,
                          country,
                          birthday,
                          branch {
                            id,
                            street,
                            city,
                            postcode,
                            country
                          },
                          ticketsSold {
                            id,
                            row,
                            column
                              }
                          }
                        }
                             
                             ";
            
             var variables = new {
                 birthday = employee.Birthday,
                 city = employee.City,
                 branchId = employee.Branch.Id,
                 country = employee.Country,
                 postcode = employee.Postcode,
                 role = employee.Role,
                 street = employee.Street,
                 email = employee.Email,
                 password = employee.Password,
                 firstName = employee.FirstName,
                 lastName = employee.LastName,
                 cpr = employee.CPR
             };
             var graphQlRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
             var graphQlResponse = new GraphQLResponse<CreateEmployeeRoot>();
             try {
                 graphQlResponse = await graphQlClient.SendMutationAsync<CreateEmployeeRoot>(graphQlRequest);
             }
             catch (Exception e) {
                 throw;
             }
             
             return graphQlResponse.Data.createEmployee;
        }

        public async Task<Employee> EditEmployee(Employee employee)
        {

            string query = @"
mutation ($id : Int!, $email : String!, $firstName : String!, $lastName : String!, $password: String!
$role : Int!, $cpr: String!, $street: String!, $city: String!, $postcode: String!
$country : String!, $birthday : String!, $branchId : Int!) {
  editEmployee (input: {id: $id, email : $email, firstName : $firstName, lastName : $lastName
  password : $password, role: $role, cpr : $cpr, street : $street, city : $city, postcode : $postcode
  country : $country, birthday : $birthday, branchId: $branchId}) {
id,     
 email,
      firstName,
      lastName,
      password,
      role,
      cPR,
      city,
      street,
      postcode,
      country,
      birthday,
      branch {
        id,
        street,
        city,
        postcode,
        country
      },
      ticketsSold {
        id,
        row,
        column
      }
  }
}


                    ";
            
            
            var variables = new {
                id = employee.Id,
                birthday = employee.Birthday,
                city = employee.City,
                branchId = employee.Branch.Id,
                country = employee.Country,
                postcode = employee.Postcode,
                role = employee.Role,
                street = employee.Street,
                email = employee.Email,
                password = employee.Password,
                firstName = employee.FirstName,
                lastName = employee.LastName,
                cpr = employee.CPR
            };
            
            var graphQlRequest = GraphQLUtility.MakeGraphQLRequest(query, variables);
            var graphQlResponse = new GraphQLResponse<EditEmployeeRoot>();
            try {
                graphQlResponse = await graphQlClient.SendMutationAsync<EditEmployeeRoot>(graphQlRequest);
            }
            catch (Exception e) {
                throw;
            }

            return graphQlResponse.Data.editEmployee;

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
            return graphQlResponse.Data.deleteEmployee;
        }

        public async Task<Employee> GetEmployee(int employeeId) {
            string query = @"query($id: Int!) {employee(id:$id){
                                id,
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
                              birthday,
                                    branch {
        id,
        street,
        city,
        postcode,
        country
      },      ticketsSold {
        id,
        row,
        column
      }
                              
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
id,
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
                              birthday,
                                                              branch {
        id,
        street,
        city,
        postcode,
        country
      }, 
                                    ticketsSold {
        id,
        row,
        column
      }
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