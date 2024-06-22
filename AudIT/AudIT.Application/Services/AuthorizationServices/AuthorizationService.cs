using System.Security.Claims;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Models.Misc;
using AudIT.Applicationa.Services.UtilsServices;
using AudiT.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Services.AuthorizationServices;

using AudIT.Applicationa.Contracts.Identity;

public class AuthorizationService(
    UtilsService utilsService,
    IInstitutionRepository institutionRepository,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager
) : IAuthorization
{
    /// <summary>
    /// Decodes the token and validates the user.
    /// </summary>
    /// <param name="token">The token that is received </param>
    /// <returns></returns>
    public async Task<(int, string)> ValidateUser(string token)
    {
        Console.WriteLine("Validating user");
        string userId = "";
        //validate the token
        if (string.IsNullOrEmpty(token))
        {
            return (0, "Token is empty");
        }

        //validate the token signature
        if (!utilsService.ValidateToken(token))
        {
            return (0, "Invalid token");
        }

        //decode the token
        try
        {
            userId = utilsService.DecodeTokenForValidating(token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (0, "Failed to decode token");
        }

        //change the user status to active
        //TODO implement the logic to change the user status to active

        var user = userManager.FindByIdAsync(userId);

        var userDomain = user.Result?.Email?.Split('@')[1];


        //set the institution to the user

        if (user.Result == null)
        {
            return (0, "User not found");
        }

        if (user.Result.Verified)
        {
            return (0, "User already verified");
        }

        //change the user status to active
        user.Result.VerifyUser();
        //save the changes


        userManager.UpdateAsync(user.Result);
        //update the user role

        if (!roleManager.RoleExistsAsync(UserRoles.Verified).Result)
        {
            await userManager.RemoveFromRoleAsync(user.Result, UserRoles.Unverified);
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Verified));
            await userManager.AddToRoleAsync(user.Result, UserRoles.Verified);
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            await userManager.AddToRoleAsync(user.Result, UserRoles.User);
        }

        //update the user claims
        var claims = await userManager.GetClaimsAsync(user.Result);
        await userManager.RemoveClaimsAsync(user.Result, claims);
        await userManager.AddClaimAsync(user.Result, new Claim(ClaimTypes.Role, UserRoles.Verified));
        await userManager.AddClaimAsync(user.Result, new Claim(ClaimTypes.Role, UserRoles.User));



        //set the department to the user


     await   userManager.UpdateAsync(user.Result);


        return (1, "User verified successfully");
    }
}