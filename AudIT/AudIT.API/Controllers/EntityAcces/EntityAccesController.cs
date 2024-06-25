using System.Security.Claims;
using AudIT.Applicationa.Requests.EntityAcces.Commands.Create;
using AudIT.Applicationa.Requests.EntityAcces.Commands.Remove;
using AudIT.Applicationa.Requests.EntityAcces.Queries.GetAllByUser;
using AudIT.Applicationa.Requests.EntityAcces.Queries.GetAllGrantedByUser;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.EntityAcces;

[ApiController]
[Route("api/[controller]")]
public class EntityAccesController : BaseController
{
    [HttpPost]
    [Route("create-entity-acces")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateEntityAcces([FromBody] CreateEntityAccesCommand command)
    {
        var userId = this.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        command.GrantedByUserId = userId;

        var result = await Mediator.Send(command);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-all-granted-acces-by-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllGrantedAccesByUser()
    {
        var userId = this.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if(userId == null)
            return BadRequest("User not found");

        var result = await Mediator.Send(new GetAllGrantedAccesByUserIdQuery(Guid.Parse(userId)));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-all-acces-by-user/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAccesByUser(Guid userId)
    {
        var result = await Mediator.Send(new GetAllAccesByUserIdQuery(userId));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpDelete]
    [Route("remove-entity-acces/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveEntityAcces(Guid id)
    {
        var result = await Mediator.Send(new RemoveAccesCommand(id));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}