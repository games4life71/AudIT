using AudIT.Applicationa.Contracts.EmailServices;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Models.AuthDTO;
using AudIT.Applicationa.Models.Misc;
using AudiT.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthentificationController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IEmailService _emailService;
    private readonly IAuthorization _authorizationService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthentificationController(IAuthService authService, IEmailService emailService,
        IAuthorization authorizationService, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _authService = authService;
        _emailService = emailService;
        _authorizationService = authorizationService;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationModel model)
    {
        Console.WriteLine("Registering user");

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }

            var (status, message) = await _authService.Registration(model, UserRoles.Unverified);

            if (status == 0)
            {
                return BadRequest(message);
            }
            //find the institution

            return Ok(message);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }

            var (status, message) = await _authService.Login(model);
            var newUser = await _userManager.FindByEmailAsync(model.Email);
            if (newUser != null) await _signInManager.SignInAsync(newUser, false);

            if (status == 0)
            {
                return BadRequest(message);
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(2),
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("jwt", message, cookieOptions);
            return Ok(message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("verify-email/{token}")]
    public async Task<IActionResult> VerifyEmail(string token)
    {
        Console.WriteLine("Verifying email");
        try
        {
            var (status, message) = await _authorizationService.ValidateUser(token);

            if (status == 0)
            {
                return BadRequest(message);
            }

            return Ok(message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("test")]
    [Authorize]
    public async Task<IActionResult> GetUser()
    {
        //if the user is not logged in return unauthorized
        if (User.Identity?.Name == null)
        {
            return Unauthorized();
        }

        return Ok("User is logged in");

    }
}