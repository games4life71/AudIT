using System.Security.Claims;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Models.AuthDTO;
using AudIT.Applicationa.Services.EmailServices;
using AudIT.Applicationa.Services.UtilsServices;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AudIT.Applicationa.Services.AuthServices;

using AudIT.Applicationa.Contracts.Identity;

public class AuthService(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration,
    IInstitutionRepository institutionRepository,
    EmailService emailService,
    UtilsService utilsService,
    SignInManager<User> signInManager,
    IUserInstitutionRepository userInstitutionRepository
)
    : IAuthService // This is the implementation of the IAuthService interface
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IInstitutionRepository _institutionRepository = institutionRepository;
    private readonly EmailService _emailService = emailService;
    private readonly UtilsService _utilsService = utilsService;
    private readonly IUserInstitutionRepository _userInstitutionRepository = userInstitutionRepository;

    public async Task<(int, string)> Registration(RegistrationModel model, string role)
    {
        var userExist = await userManager.FindByNameAsync(model.UserName);
        if (userExist != null)
        {
            return (0, "User already exists!");
        }

        // Console.WriteLine("Email is aaaaaa: " + model.EmailAddress);

        var emailExist = await userManager.FindByEmailAsync(model.EmailAddress);
        if (emailExist != null)
        {
            return (0, "Email already exists!");
        }


        var new_user = User.Create(
            model.UserName,
            model.EmailAddress,
            model.Address,
            model.PhoneNumber
        );


        if (new_user.IsSuccess == false)
        {
            Console.WriteLine(new_user.Error);
            return (0, new_user.Error);
        }


        IdentityResult result;
        var newUserValue = new_user.Value;


        var emailDomain = model.EmailAddress.Split('@')[1];

        var institution = await _institutionRepository.FindInstitutionByDomainAsync(emailDomain);

        if (institution.IsSuccess == false)
        {
            return (0, $"No institutioon with domain {emailDomain} found");
        }

        //add the institution to the user


        // Console.WriteLine("FOUND THE INSTITURION");
        var institutionAdmin = institution.Value.InstitutionAdmin;
        if (institutionAdmin == null)
        {
            // Console.WriteLine("INSTITUTION ADMIN IS NULL");
        }

        Console.WriteLine("INSTITUTION : " + institution.Value.Id);
        // if (institutionAdmin == null)
        // {
        //     return (0, "Institution admin not found");
        // }

        if (institutionAdmin != null)
        {
            Console.WriteLine("INSTITUTION ADMIN IS NOT NULL");
        }

        var emailResult = await emailService.SendAuthorizeEmail(institutionAdmin.Id, newUserValue);

        if (emailResult.Item2 == false)
        {
            return (0, "Email not sent");
        }

        try
        {
            result = await userManager.CreateAsync(newUserValue, model.Password);


            if (!result.Succeeded)
            {
                return (1, "Failed to create user");
            }

            //add the institution to the user
            var userInstitution = UserInstitution.Create(
                newUserValue.Id,
                institution.Value.Id,
                institution.Value
            );

            if (userInstitution.IsSuccess)
            {
                //save it to the database
                await _userInstitutionRepository.AddAsync(userInstitution.Value);
            }


            await roleManager.CreateAsync(new IdentityRole(role));
            await userManager.AddToRoleAsync(newUserValue, role);
        }
        //get the user
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (0, e.Message);
        }


        return (1, "User created successfully!");
    }

    public async Task<(int, string)> Login(LoginModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return (0, "User not found!");
        }

        if (!await userManager.CheckPasswordAsync(user, model.Password))
        {
            return (0, "Invalid credentials");
        }


        //attach the roles
        var userRoles = await userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };


        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        // Add the claims to the user
        foreach (var claim in authClaims)
        {
            if ((await userManager.GetClaimsAsync(user)).All(c => c.Type != claim.Type))
            {
                await userManager.AddClaimAsync(user, claim);
            }
        }

        var claimsIdentity = new ClaimsIdentity(authClaims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties();

        await signInManager.Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);

        var token = utilsService.GenerateToken(authClaims);

        return (1, token);
    }

    public async Task<Result<List<User>>> GetAllUsersByInstitutionId(Guid institutionId)
    {
        var results = await userInstitutionRepository.GetAllUsersByInstitutionId(institutionId);

        if (!results.IsSuccess)
        {
            return Result<List<User>>.Failure("No users found");
        }

        return Result<List<User>>.Success(results.Value);
    }
}