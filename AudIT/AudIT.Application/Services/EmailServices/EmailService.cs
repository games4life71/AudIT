using System.Security.Claims;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Services.AuthServices;
using AudiT.Domain.Entities;
using AudIT.Applicationa.Services;
using AudIT.Applicationa.Services.UtilsServices;
using Microsoft.IdentityModel.JsonWebTokens;

namespace AudIT.Applicationa.Services.EmailServices;


/// <summary>
/// This class is responsible for sending emails to users.
/// </summary>
public class EmailService(
    IAuthorization authorizationService,
    UtilsService utilsService
    )
{
    private readonly IAuthorization _authorizationService = authorizationService;
    private readonly UtilsService _utilsService = utilsService;

    /// <summary>
    /// Sends an email to the institution responsible for authorizing the user.
    /// The email contains information about the user and a link to authorize the user.
    /// </summary>
    /// <returns></returns>
    public async Task<bool> SendAuthorizeEmail(string adminId, User user)
    {

        //generate token
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Sid, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        //TODO implement the email sending logic
        return true;
    }
}
