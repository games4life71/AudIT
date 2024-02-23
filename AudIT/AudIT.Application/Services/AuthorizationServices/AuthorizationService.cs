using AudIT.Applicationa.Services.UtilsServices;
using AudiT.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Services.AuthorizationServices;

using AudIT.Applicationa.Contracts.Identity;

public class AuthorizationService(
    UtilsService utilsService,
    UserManager<User> userManager) : IAuthorization
{
    /// <summary>
    /// Decodes the token and validates the user.
    /// </summary>
    /// <param name="token">The token that is received </param>
    /// <returns></returns>
    public Task<(int, string)> ValidateUser(string token)
    {
        string userID = "";
        //decode the token
        try
        {
            userID = utilsService.DecodeTokenForValidating(token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Task.FromResult((0, "Failed to decode token"));
        }

        //change the user status to active
        //TODO implement the logic to change the user status to active

        var user = userManager.FindByIdAsync(userID);
        if (user.Result == null)
        {
            return Task.FromResult((0, "User not found"));
        }

        //change the user status to active
        user.Result.VerifyUser();
        //save the changes
        userManager.UpdateAsync(user.Result);

        return Task.FromResult((1, "User verified successfully"));
    }
}