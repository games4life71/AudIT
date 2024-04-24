using AudIT.Applicationa.Models.Misc;
using AudIT.Applicationa.Services.UtilsServices;
using AudiT.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Services.AuthorizationServices;

using AudIT.Applicationa.Contracts.Identity;

public class AuthorizationService(
    UtilsService utilsService,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager
    ) : IAuthorization
{
    /// <summary>
    /// Decodes the token and validates the user.
    /// </summary>
    /// <param name="token">The token that is received </param>
    /// <returns></returns>
    public Task<(int, string)> ValidateUser(string token)
    {

        Console.WriteLine("Validating user");
        string userId = "";
        //validate the token
        if (string.IsNullOrEmpty(token))
        {
            return Task.FromResult((0, "Token is empty"));
        }
        //validate the token signature
        if (!utilsService.ValidateToken(token))
        {
            return Task.FromResult((0, "Invalid token"));
        }

        //decode the token
        try
        {
            userId = utilsService.DecodeTokenForValidating(token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Task.FromResult((0, "Failed to decode token"));
        }

        //change the user status to active
        //TODO implement the logic to change the user status to active

        var user = userManager.FindByIdAsync(userId);
        if (user.Result == null)
        {
            return Task.FromResult((0, "User not found"));
        }

        if(user.Result.Verified)
        {
            return Task.FromResult((0, "User already verified"));
        }

        //change the user status to active
        user.Result.VerifyUser();
        //save the changes
        userManager.UpdateAsync(user.Result);
            //update the user role

        if (!roleManager.RoleExistsAsync(UserRoles.Verified).Result)
        {
            userManager.RemoveFromRoleAsync(user.Result, UserRoles.Unverified);
            userManager.AddToRoleAsync(user.Result, UserRoles.Verified);
            userManager.AddToRoleAsync(user.Result, UserRoles.User);
        }



        return Task.FromResult((1, "User verified successfully"));
    }
}