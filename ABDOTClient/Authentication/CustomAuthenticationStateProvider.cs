using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using ABDOTClient.Model;
using ABDOTClient.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;


namespace ABDOTClient.Authentication{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider{
        private readonly IJSRuntime jsRuntime;
        public Employee cachedUser;
        private readonly IEmployeeService employeeService;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IEmployeeService employeeService){
            this.jsRuntime = jsRuntime;
            this.employeeService = employeeService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync(){
            var identity = new ClaimsIdentity();
            if (cachedUser == null){
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson)){
                    cachedUser = JsonSerializer.Deserialize<Employee>(userAsJson);
                    identity = SetupClaimsForUser(cachedUser);
                }
            }
            else{
                identity = SetupClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(string username, string password){
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            ClaimsIdentity identity = new ClaimsIdentity();
            try{
                Employee user = await employeeService.LoginEmployee(username, password);
                if (user == null) throw new Exception("Incorrect credentials");
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
            }
            catch (Exception e){
                throw e;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public async Task Logout(){
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity SetupClaimsForUser(Employee user){
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim("Role", user.Role.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}