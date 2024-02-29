using AudIT.Applicationa.Requests.ObjectiveActions.Commands.Add.AddActionRisk;
using AudIT.Applicationa.Requests.ObjectiveActions.Commands.Create;
using AudiT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.ObjectiveActionController;

public class ObjectiveActionController : BaseController
{
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
}