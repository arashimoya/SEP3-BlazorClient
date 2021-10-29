using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using ABDOTClient.Model;
using Assignment1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;




namespace Assignment1.Authentication {
public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
    private readonly IJSRuntime jsRuntime;
    private  IUserService userService;

    private User cachedUser;

    public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUserService userService) {
        this.jsRuntime = jsRuntime;
        this.userService = userService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        var identity = new ClaimsIdentity();
        if (cachedUser == null) {
            string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
            if (!string.IsNullOrEmpty(userAsJson)) {
                User tmp = JsonSerializer.Deserialize<User>(userAsJson);
                ValidateLogin(tmp.Email, tmp.Password);
            }
        } else {
            identity = SetupClaimsForUser(cachedUser);
        }

        ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
        return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
    }

    public void ValidateLogin(string username, string password) {
        Console.WriteLine("Validating log in");
        if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
        if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

        ClaimsIdentity identity = new ClaimsIdentity();
        try {
            User user = userService.ValidateUser(username, password);
            identity = SetupClaimsForUser(user);
            string serialisedData = JsonSerializer.Serialize(user);
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
            cachedUser = user;
        } catch (Exception e) {
            throw e;
        }

        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
    }

    public void Logout() {
        cachedUser = null;
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void ValidateRegister(string email, string password, string confirmPassword, string firstName, 
        string lastName, string streetAndHouseNumber, string city, string postcode, string country)
    {
        if (string.IsNullOrEmpty(email)) throw new Exception("Enter your e-mail");
        if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
        if (string.IsNullOrEmpty(confirmPassword)) throw new Exception("Confirm password");
        if (userService.IsAlreadyInUse(email)) throw new Exception("This email is already in use");
        if (!password.Equals(confirmPassword)) throw new Exception("Passwords do not match!");
        
        userService.RegisterUser(email,password, firstName, lastName, streetAndHouseNumber, city, postcode, country);
    }

    private ClaimsIdentity SetupClaimsForUser(User user) {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, user.Email));
        

        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
        return identity;
    }
}
}