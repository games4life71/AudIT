using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Models.AuthDTO;
using AudIT.Applicationa.Models.Misc;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthentificationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthentificationController(IAuthService authService)
    {
        _authService = authService;
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
}