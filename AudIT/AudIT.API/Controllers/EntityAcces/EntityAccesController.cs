using AudIT.Applicationa.Requests.EntityAcces.Commands.Create;
using AudIT.Applicationa.Requests.EntityAcces.Queries.GetAllByUser;
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
        var result = await Mediator.Send(command);

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
}