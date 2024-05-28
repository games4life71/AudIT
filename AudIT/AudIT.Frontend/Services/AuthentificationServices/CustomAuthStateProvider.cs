using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Frontend.Services.AuthentificationServices;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    // private ClaimsPrincipal _claimsPrincipal;
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public CustomAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        // _claimsPrincipal = claimsPrincipal;
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    /// <summary>
    /// This method makes a call to the server to get the current user's authentication state.
    /// </summary>
    /// <returns></returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
         int MaxRetries = 10;
        ClaimsPrincipal claimsPrincipal;
        var response = await _httpClient.GetAsync("http://localhost:5071/api/v1/Authentification/get-user-claims");
        while (!response.IsSuccessStatusCode && MaxRetries > 0)
        {
            await Task.Delay(1000); // Wait for 1 second
            response = await _httpClient.GetAsync("http://localhost:5071/api/v1/Authentification/get-user-claims");
            MaxRetries--;
        }
        if (response.IsSuccessStatusCode)
        {
            var claims = await response.Content.ReadFromJsonAsync<List<ClaimResponse>>();
            claimsPrincipal =
                new ClaimsPrincipal(new ClaimsIdentity(claims.Select(c => new Claim(c.Type, c.Value)), "AuthCookie"));
        }
        else
        {
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        }

        // Create a DTO and save it to local storage
        var claimsPrincipalDto = new ClaimsPrincipalDto
        {
            Claims = claimsPrincipal.Claims.Select(c => new ClaimResponse(c.Type, c.Value)).ToList()
        };
        await _localStorage.SetItemAsync("auth", claimsPrincipalDto);

        return new AuthenticationState(claimsPrincipal);
    }

    public List<ClaimResponse> GetClaims(AuthenticationState authState)
    {
        return authState.User.Claims.Select(c => new ClaimResponse(c.Type, c.Value)).ToList();
    }

    public async void SignOut()
    {

        //make a call to logout endpoint
        var response = await _httpClient.GetAsync("https://localhost:7248/api/v1/Authentification/logout");

        //remove the auth from local storage


        _localStorage.RemoveItemAsync("auth");
        //sign out the user
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
    }
}

public class ClaimsPrincipalDto
{
    public List<ClaimResponse> Claims { get; set; }
}