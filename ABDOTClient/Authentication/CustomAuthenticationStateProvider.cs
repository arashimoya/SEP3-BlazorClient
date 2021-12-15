using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;




namespace ABDOTClient.Authentication {
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
        public readonly IJSRuntime jsRuntime;
        private readonly IUserService userService;
        private readonly IEmployeeService employeeService;
        public User cachedUser { get; set; }
        public Employee cachedEmployee { get; set; }

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService, IEmployeeService employeeService)
        {
            this.jsRuntime = jsRuntime;
            this.userService = userService;
            this.employeeService = employeeService;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                if (cachedEmployee == null) {
                    string employeeAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentEmployee");
                    if (!string.IsNullOrEmpty(employeeAsJson))
                    {
                        cachedEmployee = JsonSerializer.Deserialize<Employee>(employeeAsJson);
                        identity = SetupClaimsForEmployee(cachedEmployee);
                    }
                }
                else {
                    identity = SetupClaimsForEmployee(cachedEmployee);
                }
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    cachedUser = JsonSerializer.Deserialize<User>(userAsJson);
                    identity = SetupClaimsForUser(cachedUser);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string username, string password)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            
            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                User user = await userService.ValidateUser(username, password);
                Debug.WriteLine("Here 1");
                if (user.GetType() != typeof(User)) {
                    Console.WriteLine("Here 2");
                    Employee employee = await employeeService.LoginEmployee(username, password);
                    Console.WriteLine("Here 3");
                    
                    if (employee == null) 
                        throw new Exception("Incorrect credentials");
                    
                    Console.WriteLine("Here 4");
                        Console.WriteLine(employee);
                        identity = SetupClaimsForEmployee(employee);
                        string serialisedData = JsonSerializer.Serialize(employee);
                        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentEmployee", serialisedData);
                        Console.WriteLine("Here 5");
                        cachedEmployee = employee;
                        Console.WriteLine(cachedEmployee);
                } else {
                    Console.WriteLine(user);
                    identity = SetupClaimsForUser(user);
                    string serialisedData = JsonSerializer.Serialize(user);
                    await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                    cachedUser = user;
                    Console.WriteLine(cachedUser);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public async Task Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            
            cachedEmployee = null;
            var employee = new ClaimsPrincipal(new ClaimsIdentity());
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentEmployee", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(employee)));
        }
        
        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            // Working prototype
            claims.Add(new Claim("Email", user.Id.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        private ClaimsIdentity SetupClaimsForEmployee(Employee employee)
        {
            List<Claim> claims = new List<Claim>();
            // claims.Add(new Claim("Email", employee.Email));
            // claims.Add(new Claim("Role", employee.Role.ToString()));
            // claims.Add(new Claim("Role", Convert.ToString(employee.Role)));

            
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }

        public async Task<bool>  ValidateRegister(string email, string password, string confirmPassword, string firstName, 
            string lastName, string streetAndHouseNumber, string city, string postcode, string country)
        {
            Console.WriteLine("auth");
            //if (string.IsNullOrEmpty(email)) throw new Exception("Enter your e-mail");
            //if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            //if (string.IsNullOrEmpty(confirmPassword)) throw new Exception("Confirm password");
            //if (userService.IsAlreadyInUse(email)) throw new Exception("This email is already in use");
            //if (!password.Equals(confirmPassword)) throw new Exception("Passwords do not match!");
            User returnedUser = await userService.RegisterUser(email, password, firstName, lastName, streetAndHouseNumber,
                city, postcode,
                country);
            if (returnedUser != null && returnedUser.GetType() == typeof(User))
            {
                return true;
            }

            return false;
        }

        
    }
}