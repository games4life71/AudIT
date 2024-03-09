using AudIT.Applicationa.Requests.ObjectiveActions.Commands.Add.AddActionRisk;
using AudIT.Applicationa.Requests.ObjectiveActions.Commands.Create;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetAllSelected;
using AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetBy.ObjectiveId;
using AudIT.Applicationa.Requests.ObjectiveActions.Update.UpdateActionRisk;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.ObjectiveActionController;

public class ObjectiveActionController : BaseController
{
    public ObjectiveActionController()
    {
    }

    [HttpPost]
    [Route("add-new-objective-action")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddObjectiveAction(CreateBaseObjActionCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpPost]
    [Route("add-action-risk")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddActionRisk(AddActionRiskCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("get-objective-actions/{objectiveId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetObjectiveActions(Guid objectiveId)
    {
        var result = await Mediator.Send(new GetObjectiveActionsByObjID(new Guid(objectiveId.ToString())));
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpPut]
    [Route("update-objective-action-risk/{actionRiskId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateObjectiveActionRisk(Guid actionRiskId, UpdateActionRiskCommand command)
    {
        command.ActionRiskId = actionRiskId;
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("add-action-risks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddActionRisks(List<AddActionRiskCommand> commands)
    {
        BaseDTOResponse<ObjActionWithRisksDto> lastResult = new();
        foreach (var command in commands)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            lastResult = result;
        }

        return Ok(lastResult);
    }


    [HttpGet]
    [Route("get-selected-objective-actions/{objectiveId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSelectedObjectiveActions(Guid objectiveId)
    {
        var result = await Mediator.Send(new GetAllObjActionsCommand(new Guid(objectiveId.ToString())));
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}