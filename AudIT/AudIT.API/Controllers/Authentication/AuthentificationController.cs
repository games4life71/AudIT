using System.Security.Claims;
using AudIT.Applicationa.Contracts.EmailServices;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Models.AuthDTO;
using AudIT.Applicationa.Models.Misc;
using AudIT.Applicationa.Requests.User.Commands.UpdateUserInfo;
using AudIT.Applicationa.Requests.User.Dto;
using AudIT.Applicationa.Requests.User.Queries.GetInformation;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
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
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthentificationController(IAuthService authService, IEmailService emailService,
        IAuthorization authorizationService, UserManager<User> userManager, SignInManager<User> signInManager,
        IHttpContextAccessor httpContextAccessor, IMediator mediator, IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _authService = authService;
        _emailService = emailService;
        _authorizationService = authorizationService;
        _userManager = userManager;
        _signInManager = signInManager;
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpGet]
    [Route("get-user-information")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserInformation()
    {
        try
        {
            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userInformation = await _mediator.Send(new GetUserInformationQuery(userId));

            if (userInformation.Success)
            {
                return Ok(userInformation);
            }

            return BadRequest(userInformation.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPatch]
    [Route("update-user-information")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateUserInformation(UpdateUserInfoCommand command)
    {
        try
        {

            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            command.Id = userId;
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    [HttpGet]
    [Route("get-user-claims")]
    public async Task<IActionResult> GetUserClaims()
    {
        //get the user claims
        var user = _httpContextAccessor.HttpContext?.User;

        if (user == null || !user.Claims.Any())
        {
            return BadRequest("No user is currently authenticated or there are no claims.");
        }

        var claims = user.Claims.Select(c => new { c.Type, c.Value }).ToList();
        return Ok(claims);
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
        //print the request
        Console.WriteLine("Logging in user");
        Console.WriteLine(model.Email);
        Console.WriteLine(model.Password);


        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid payload");
            }

            Console.WriteLine("Logging in user");
            var (status, message) = await _authService.Login(model);
            var newUser = await _userManager.FindByEmailAsync(model.Email);
            if (newUser != null) await _signInManager.SignInAsync(newUser, false);

            if (status == 0)
            {
                return BadRequest(message);
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(2),
                SameSite = SameSiteMode.None
            };

            // Response.Cookies.Append("jwt", message, cookieOptions);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        Console.WriteLine("Logging out user");
        try
        {
            //set the expiration time to 1 second ago
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                Expires = DateTime.UtcNow.AddSeconds(-1),
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("jwt", "", cookieOptions);
            await _signInManager.SignOutAsync();
            return Ok();
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
    [Route("get-all-users-by-institution-id/{institutionId}")]
    public async Task<IActionResult> GetAllUsersByInstitutionId(Guid institutionId)
    {
        Console.WriteLine("Getting all users by institution id");
        try
        {
            var users = await _authService.GetAllUsersByInstitutionId(institutionId);

            var mappedUsers = _mapper.Map<List<UserInformationWithIdDto>>(users.Value);

            var responseDto = new BaseDTOResponse<UserInformationWithIdDto>(mappedUsers, "Succes", true);

            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}