﻿using AudIT.Applicationa.Contracts.EmailServices;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Models.AuthDTO;
using AudIT.Applicationa.Models.Misc;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthentificationController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IEmailService _emailService;
    private readonly IAuthorization _authorizationService;

    public AuthentificationController(IAuthService authService, IEmailService emailService, IAuthorization authorizationService)
    {
        _authService = authService;
        _emailService = emailService;
        _authorizationService = authorizationService;
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
}