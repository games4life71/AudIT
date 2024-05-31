using AudIT.Applicationa.Requests.Objective.Commands.Create;
using AudIT.Applicationa.Requests.Objectives.Commands.Patch.RemoveObjectiveAction;
using AudIT.Applicationa.Requests.Objectives.Commands.Patch.UpdateObjName;
using AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.GetByAuditMissionId;
using AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.Id;
using AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.MostRecent;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.ObjectiveController;

public class ObjectiveController : BaseController
{
    [HttpPost]
    [Route("add-new-objective")]
    public async Task<IActionResult> AddNewObjective([FromBody] CreateObjectiveCommand command)
    {
        try
        {
            var response = await Mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("get-objective-by-id")]
    public async Task<IActionResult> GetObjectiveById(Guid id)
    {
        try
        {
            var response = await Mediator.Send(new GetObjByIdQuery(id));
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("update-objective-name")]
    public async Task<IActionResult> UpdateObjectiveName(UpdateObjectiveNameCommand command)
    {
        try
        {
            var response = await Mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("remove-objective-action")]
    public async Task<IActionResult> RemoveObjectiveAction(RemoveObjActionCommand command)
    {
        try
        {
            var response = await Mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("get-objective-by-audit-mission-id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetObjectiveByAuditMissionId(Guid auditMissionId)
    {
        try
        {
            var response = await Mediator.Send(new GetObjectiveByAuditMissionIdQuery
                { AuditMissionId = auditMissionId });
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("get-most-recent-objective-by-audit-mission-id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMostRecentObjectiveByAuditMissionId(Guid auditMissionId)
    {
        try
        {
            var response = await Mediator.Send(new GetMostRecentObjByAuditMissionIdQuery
                { AuditMissionId = auditMissionId });
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}