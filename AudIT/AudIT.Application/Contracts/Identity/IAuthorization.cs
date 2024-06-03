namespace AudIT.Applicationa.Contracts.Identity;



/// <summary>
/// This interface handles the authorization of users.
/// </summary>
public interface IAuthorization
{


    public Task<(int, string)> ValidateUser(string token);

}