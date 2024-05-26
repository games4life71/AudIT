using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Frontend.Services.AuthentificationServices;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _claimsPrincipal;
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public CustomAuthStateProvider(ClaimsPrincipal claimsPrincipal, HttpClient httpClient,ILocalStorageService localStorage)
    {
        _claimsPrincipal = claimsPrincipal;
        _httpClient = httpClient;
        _localStorage = localStorage;
    }
    /// <summary>
    /// This method makes a call to the server to get the current user's authentication state.
    /// </summary>
    /// <returns></returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        var response = await _httpClient.GetAsync("http://localhost:5071/api/v1/Authentification/get-user-claims");

            if (response.IsSuccessStatusCode)
            {
                var claims = await response.Content.ReadFromJsonAsync<List<ClaimResponse>>();
                _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims.Select(c => new Claim(c.Type, c.Value)), "AuthCookie"));

            }
            else
            {
                _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            }

            //save it to local storage
            await _localStorage.SetItemAsync("auth", _claimsPrincipal);

            return new AuthenticationState(_claimsPrincipal);
    }

    public  List<ClaimResponse> GetClaims()
    {
        return _claimsPrincipal.Claims.Select(c => new ClaimResponse(c.Type, c.Value)).ToList();
    }
}