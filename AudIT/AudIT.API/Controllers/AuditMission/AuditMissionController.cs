using AudIT.Applicationa.Requests.AuditMission.Commands.Create;
using AudIT.Applicationa.Requests.AuditMission.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.AuditMission;

public class AuditMissionController : BaseController
{
    [HttpPost]
    [Route("add-audit-mission")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAuditMission(CreateBaseAuditMIssionCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-audit-mission/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuditMission(Guid id)
    {
        var result = await Mediator.Send(new GetByIdQuery(id));
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }



}