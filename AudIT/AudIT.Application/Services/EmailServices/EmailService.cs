using System.Security.Claims;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using AudIT.Applicationa.Contracts.EmailServices;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Services.AuthServices;
using AudiT.Domain.Entities;
using AudIT.Applicationa.Services;
using AudIT.Applicationa.Services.UtilsServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using RazorLight;

namespace AudIT.Applicationa.Services.EmailServices;

/// <summary>
/// This class is responsible for sending emails to users.
/// </summary>
public class EmailService(
    IAuthorization authorizationService,
    UtilsService utilsService,
    UserManager<User> _userManager) : IEmailService
{
    private readonly IAuthorization _authorizationService = authorizationService;
    private readonly UtilsService _utilsService = utilsService;

    /// <summary>
    /// Sends an email to the institution responsible for authorizing the user.
    /// The email contains information about the user and a link to authorize the user.
    /// </summary>
    /// <returns></returns>
    public async Task<(string, bool)> SendAuthorizeEmail(string adminId, User user)
    {
        //generate token
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Sid, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var admin = await _userManager.FindByIdAsync(adminId);
        if (admin == null)
        {
            return (" Admin not found", false);
        }


        var emailModel = new
        {
            UserName = admin.UserName,
            Email = user.Email,
            VerificationLink = "http://localhost:5071/api/v1/Authentification/verify-email/" + _utilsService.GenerateToken(claims)
        };

        // var engine = new RazorLightEngineBuilder()
        //     .UseMemoryCachingProvider()
        //     .UseFileSystemProject("D:\\Projects\\AudIT\\AudIT\\AudIT\\AudIT.Application\\Templates\\EmailTemplates")
        //     .Build();

        var emailBody =
            "@\n<" +
            "!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "    <title>User Verification Email</title>\n" +
            "</head>\n" +
            "<body>\n" +
            "    <h1>User Verification</h1>\n" +
            "    <p>Dear Admin,</p>\n" +
            "    <p>A new user has registered on our website and requires verification.</p>\n " +
            "   <p>User details:</p>\n " +
            $"   <p>Username: {emailModel.UserName}>\n   " +
            $" <p>Email: {emailModel.Email}</p>\n   " +
            " <p>Please click the link below to verify the user:</p>\n   " +
            $" <a href='{emailModel.VerificationLink}'>Verify User</a>\n   " +
            " <p>Best Regards,</p>\n" +
            "    <p>Your Website Team</p>\n" +
            "</body>\n" +
            "</html>";

        try
        {
            var result = await SendEmailAsync("7stefanadrian@gmail.com", "User registration", emailBody);

            return result.Item2 ? ("Email sent successfully", true) : ("Email not sent", false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return ("Email not sent", false);
        }
    }


    public async Task<(string, bool)> SendEmailAsync(string recipient, string subject, string htmlMessage)
    {
        try
        {
            var client = new AmazonSimpleEmailServiceClient(Amazon.RegionEndpoint.EUCentral1);
            var sendRequest = new SendEmailRequest
            {
                Source =
                    "7stefanadrian@gmail.com", // This must be verified in the Amazon SES console "Email Addresses
                Destination = new Destination { ToAddresses = [recipient] },
                Message = new Message
                {
                    Subject = new Content("Verification required for user registration"),
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = htmlMessage
                        }
                    }
                }
            };
            await client.SendEmailAsync(sendRequest);
        }
        catch (Exception ex)
        {
            // Handle the exception
            Console.WriteLine("The email was not sent.");
            Console.WriteLine("Error message: " + ex.Message);
            return ("The email was not sent: " + ex.Message, false);
        }

        return ("Email sent successfully", true);
    }
}