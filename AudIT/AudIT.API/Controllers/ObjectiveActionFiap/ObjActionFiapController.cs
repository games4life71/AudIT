using AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Create;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Delete;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Queries.GetById;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Update;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.Queries.GetByAuditMissionId;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.Queries.GetByObjectiveActionId;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.ObjectiveActionFiap;

[ApiController]
[Route("api/[controller]")]
public class ObjActionFiapController : BaseController
{
    [HttpPost]
    [Route("create-obj-action-fiap")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateObjActionFiap([FromBody] CreateObjActionFiapCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete-obj-action-fiap/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteObjActionFiap(Guid id)
    {
        var result = await Mediator.Send(new DeleteFiapCommand(id));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("get-obj-action-fiap-by-obj-action-id/{objectiveActionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetObjActionFiapByObjectiveActionId(Guid objectiveActionId)
    {
        var result = await Mediator.Send(new GetFiapByObjActionIdQuery(objectiveActionId));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("get-obj-action-fiap-by-audit-mission-id/{auditMissionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetObjActionFiapByAuditMissionId(Guid auditMissionId, bool mostRecent = false)
    {
        var result = await Mediator.Send(new GetFiapByAuditMissionIdQuery(auditMissionId, mostRecent));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-obj-action-fiap-by-id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetObjActionFiapById(Guid id)
    {
        var result = await Mediator.Send(new GetObjActionFiapByIdQuery(id));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("update-obj-action-fiap")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateObjActionFiap([FromBody] UpdateObjectiveActionFiapCommand command)
    {

        var result = await Mediator.Send(command);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}